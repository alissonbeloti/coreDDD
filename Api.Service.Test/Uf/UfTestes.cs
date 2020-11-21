using System;
using System.Collections.Generic;
using System.Text;

using Domain.Dtos.Uf;


namespace Api.Service.Test.Uf
{
    public class UfTestes
    {
        public static string Sigla { get; set; }
        public static string Nome { get; set; }
        public static Guid IdUf { get; set; }

        public List<UfDto> ufDtos = new List<UfDto>();
        public UfDto UfDto { get; set; }

        public UfTestes()
        {
            IdUf = Guid.NewGuid();
            Nome = "São Paulo";
            Sigla = "SP";
           
            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDto()
                {
                    Id = Guid.NewGuid(),
                    Nome = Nome + i,
                    Sigla = "A"+ i,
                };
                ufDtos.Add(dto);
            }

            this.UfDto = new UfDto
            {
                Id = IdUf,
                Nome = Nome,
                Sigla = Sigla,
            };
            ufDtos.Add(UfDto);
        }
    }
}
