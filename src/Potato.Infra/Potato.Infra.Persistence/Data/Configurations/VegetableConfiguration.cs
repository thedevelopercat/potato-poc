﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Potato.Domain.Models;

namespace Potato.Infra.Persistence.Data.Configurations
{
    internal sealed class VegetableConfiguration : IEntityTypeConfiguration<Vegetable>
    {
        public void Configure(EntityTypeBuilder<Vegetable> builder)
        {
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            builder.HasKey(p => p.Id).HasName("vegetables_primary_key");

            builder.Property(p => p.Name)
                .HasMaxLength(64)
                .IsRequired()
                .HasColumnName("name");

            builder.HasIndex(p => p.Name).IsUnique().HasDatabaseName("vegetables_unique_name");
            builder.HasIndex(p => p.Name).HasDatabaseName("idx_vegetables_name");

            builder.ToTable("vegetable");
        }
    }
}
