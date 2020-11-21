using System;
using System.Collections.Generic;
using System.Text;

using Domain.Dtos.Uf;

namespace Domain.Dtos.Municipio
{
    public class MunicipioDtoCompleto: MunicipioDto
    {
        public UfDto Uf { get; set; }
    }
}
