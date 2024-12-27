using Microsoft.Extensions.DependencyInjection;

namespace Potato.Application.Validation.Extensions
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            return services;
        }
    }
}
