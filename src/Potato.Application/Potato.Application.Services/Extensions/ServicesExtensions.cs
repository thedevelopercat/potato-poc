using Microsoft.Extensions.DependencyInjection;

namespace Potato.Application.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
