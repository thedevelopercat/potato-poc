using Microsoft.AspNetCore.HttpOverrides;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Potato.Infra.Persistence.Extensions;
using Potato.Web.Components;
using Serilog;
using Potato.Application.Services.Extensions;
using Potato.Application.Validation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// configuration
builder.Configuration.Sources.Clear();
builder.Configuration
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true)
    .AddUserSecrets(typeof(Program).Assembly)
    .AddEnvironmentVariables();

// logging
builder.Services.AddSerilog(cfg =>
{
    cfg.ReadFrom.Configuration(builder.Configuration);
});

// telemetry
var tracingOtlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"];
var otel = builder.Services.AddOpenTelemetry();

// Configure OpenTelemetry Resources with the application name
otel.ConfigureResource(resource => resource
    .AddService(serviceName: builder.Environment.ApplicationName));

// Add Metrics for ASP.NET Core and our custom metrics and export to Prometheus
otel.WithMetrics(metrics => metrics
    // Metrics provider from OpenTelemetry
    .AddAspNetCoreInstrumentation()
    .AddHttpClientInstrumentation()
    .AddPrometheusExporter()
);

// Add Tracing for ASP.NET Core and our custom ActivitySource and export to Jaeger
otel.WithTracing(tracing =>
{
    tracing.AddAspNetCoreInstrumentation();
    tracing.AddHttpClientInstrumentation();
    tracing.AddEntityFrameworkCoreInstrumentation();

    if (tracingOtlpEndpoint != null)
    {
        tracing.AddOtlpExporter(otlpOptions =>
        {
            otlpOptions.Endpoint = new Uri(tracingOtlpEndpoint);
        });
    }
});

// reverse proxy awareness
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

// database
builder.Services.AddPostgresSql(builder.Configuration);

// add services to the container.
builder.Services
    .AddServices()
    .AddValidation()
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseForwardedHeaders();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapPrometheusScrapingEndpoint();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync().ConfigureAwait(false);