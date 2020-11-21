using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoCreate
    {
        [Required(ErrorMessage = "Cep é campo obrigatório")]
        [StringLength(10, ErrorMessage = "Cep deve ter no máximo {1] caracteres.")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Logradouro do IBGE inválido.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Número do IBGE inválido.")] 
        public string Numero { get; set; }
        [Required(ErrorMessage = "Uf é campo obrigatório.")]
        public Guid MunicipioId { get; set; }
    }
}
