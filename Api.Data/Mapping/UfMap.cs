using System;
using System.Collections.Generic;
using System.Text;

using Api.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UfMap : IEntityTypeConfiguration<UfEntity>
    {
        public void Configure(EntityTypeBuilder<UfEntity> builder)
        {
            builder.ToTable("Uf");

            builder.HasKey(uf => uf.Id);
            builder.HasIndex(uf => uf.Sigla).IsUnique();
            builder.Property(uf => uf.Nome).HasMaxLength(50);
        }
    }
}
