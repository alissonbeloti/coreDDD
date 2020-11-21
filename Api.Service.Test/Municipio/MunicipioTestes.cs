using System;
using System.Collections.Generic;

using Domain.Dtos.Municipio;
using Domain.Dtos.Uf;

namespace Api.Service.Test.Municipio
{
    public class MunicipioTestes
    {
        public static string NomeMunicipio { get; set; }
        public static int CodigoIbgeMunicipio { get; set; }
        public static string NomeMunicipioAlterado { get; set; }
        public static int CodigoIbgeMunicipioAlterado { get; set; }
        public static Guid IdMunicipio { get; set; }
        public static Guid IdUf { get; set; }

        public List<MunicipioDtoCompleto> municipioDtos = new List<MunicipioDtoCompleto>();
        public MunicipioDto MunicipioDto { get; set; }
        public MunicipioDtoCompleto MunicipioDtoCompleto { get; set; }
        public MunicipioDtoCreate MunicipioDtoCreate { get; set; }
        public MunicipioDtoCreateResult MunicipioDtoCreateResult { get; set; }
        public MunicipioDtoUpdate MunicipioDtoUpdate { get; set; }
        public MunicipioDtoUpdateResult MunicipioDtoUpdateResult { get; set; }
        public UfDto Uf { get; set; }
        public MunicipioTestes()
        {
            IdMunicipio = Guid.NewGuid();
            IdUf = Guid.NewGuid();
            NomeMunicipio = Faker.Name.FullName();
            CodigoIbgeMunicipio = Faker.RandomNumber.Next(1000000, 9999999);
            NomeMunicipioAlterado = Faker.Name.FullName();
            CodigoIbgeMunicipioAlterado = Faker.RandomNumber.Next(1000000, 9999999);
            Uf = new UfDto
            {
                Id = IdUf,
                Nome = "São Paulo",
                Sigla = "SP"
            };
            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDtoCompleto()
                {
                    Id = Guid.NewGuid(),
                    CodIbge = Faker.RandomNumber.Next(1000000, 9999999),
                    Nome = Faker.Name.FullName(),
                    UfId = IdUf,
                    Uf = Uf,
                };
                municipioDtos.Add(dto);
            }

            this.MunicipioDto = new MunicipioDto
            {
                Id = IdMunicipio,
                CodIbge = CodigoIbgeMunicipio,
                Nome = NomeMunicipio,
                UfId = IdUf,
            };

            this.MunicipioDtoCompleto = new MunicipioDtoCompleto
            {
                Id = IdMunicipio,
                CodIbge = CodigoIbgeMunicipio,
                Nome = NomeMunicipio,
                UfId = IdUf,
                Uf = this.Uf,
            };

            this.MunicipioDtoCreate = new MunicipioDtoCreate
            {
                CodIbge = CodigoIbgeMunicipio,
                Nome = NomeMunicipio,
                UfId = IdUf,
            };

            this.MunicipioDtoCreateResult = new MunicipioDtoCreateResult
            {
                CodIbge = CodigoIbgeMunicipio,
                Nome = NomeMunicipio,
                UfId = IdUf,
                Id = IdMunicipio, 
                CreateAt = DateTime.UtcNow,
            };

            this.MunicipioDtoUpdate = new MunicipioDtoUpdate
            {
                CodIbge = CodigoIbgeMunicipioAlterado,
                Nome = NomeMunicipioAlterado,
                UfId = IdUf,
                Id = IdMunicipio,
            };

            this.MunicipioDtoUpdateResult = new MunicipioDtoUpdateResult
            {
                CodIbge = CodigoIbgeMunicipioAlterado,
                Nome = NomeMunicipioAlterado,
                UfId = IdUf,
                Id = IdMunicipio,
                UpdateAt = DateTime.UtcNow,
            };
        }
    }
}
