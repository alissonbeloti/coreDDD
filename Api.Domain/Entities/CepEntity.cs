using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Domain.Entities
{
    public class CepEntity: BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string Cep { get; set; }
        [Required]
        [MaxLength(80)]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(10)]
        public string Numero { get; set; }

        [Required]
        public Guid MunicipioId { get; set; }
        public MunicipioEntity Municipio { get; set; }
    }
}
