using Microsoft.EntityFrameworkCore;
using Potato.Domain.Models;

namespace Potato.Infra.Persistence.Data
{
    internal sealed class VegetablesContext(DbContextOptions<VegetablesContext> options) : DbContext(options)
    {
        public DbSet<Vegetable> Vegetables => Set<Vegetable>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VegetablesContext).Assembly);
            modelBuilder.HasDefaultSchema("application");
        }
    }
}
