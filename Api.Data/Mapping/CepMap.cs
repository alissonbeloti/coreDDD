using System;
using System.Collections.Generic;
using System.Text;

using Api.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<CepEntity>
    {
        public void Configure(EntityTypeBuilder<CepEntity> builder)
        {
            builder.ToTable("Cep");

            builder.HasKey(m => m.Id);
            builder.HasIndex(m => m.Cep)
                .IsUnique();

            builder.HasOne(c => c.Municipio).WithMany(m => m.Ceps)
                .HasForeignKey(c => c.MunicipioId);
        }
    }
    
}
