using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Potato.Domain.Services.Abstractions;
using Potato.Infra.Persistence.Data;
using Potato.Infra.Persistence.Repositories;

namespace Potato.Infra.Persistence.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPostgresSql(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("VegetablesDb");

            ArgumentException.ThrowIfNullOrEmpty(connectionString);

            services.AddScoped<IVegetableRepository, VegetablesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services.AddDbContext<VegetablesContext>(builder =>
            {
                builder.UseNpgsql(connectionString, options =>
                {
                    options.MigrationsAssembly(typeof(VegetablesContext).Assembly.ToString());
                });
            });
        }
    }
}
