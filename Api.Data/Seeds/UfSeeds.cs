using System;
using System.Collections.Generic;
using System.Text;

using Api.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Data.Seeds
{
    public static class UfSeeds
    {
        public static void Ufs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UfEntity>().HasData(
                new UfEntity
                {
                    Id = new Guid("65A1FB0C-25D1-4DF8-90DC-1AFB80705420"),
                    Sigla = "AC",
                    Nome = "Acre",
                    CreateAt = DateTime.UtcNow,
                },
                new UfEntity
                {
                    Id = new Guid("8F259D7F-A503-40E6-9FA3-3FE156047123"),
                    Sigla = "SP",
                    Nome = "São Paulo",
                    CreateAt = DateTime.UtcNow,
                }
                );
        }
    }
}
