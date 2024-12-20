﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Potato.Infra.Persistence.Data;

namespace Potato.Infra.Persistence.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPostgresSql(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("VegetablesDb");

            ArgumentException.ThrowIfNullOrEmpty(connectionString);

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
