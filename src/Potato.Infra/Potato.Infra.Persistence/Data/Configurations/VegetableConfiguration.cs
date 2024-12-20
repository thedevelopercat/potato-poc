using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Potato.Domain.Models;

namespace Potato.Infra.Persistence.Data.Configurations
{
    internal sealed class VegetableConfiguration : IEntityTypeConfiguration<Vegetable>
    {
        public void Configure(EntityTypeBuilder<Vegetable> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(64)
                .IsRequired();

            builder.HasIndex(p => p.Name).IsUnique().HasDatabaseName("UK_Vegetable_Name");
            builder.HasIndex(p => p.Name).HasDatabaseName("IX_Vegetable_Name");

            builder.ToTable("vegetable");
        }
    }
}
