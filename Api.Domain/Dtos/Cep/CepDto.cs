using System;
using System.Collections.Generic;
using System.Text;

using Domain.Dtos.Municipio;

namespace Api.Domain.Dtos.Cep
{
    public class CepDto
    {
        public Guid Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioDto Municipio { get; set; }

    }
}
