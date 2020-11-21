using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace Domain.Dtos.Municipio
{
    public class MunicipioDtoUpdate
    {
        [Required(ErrorMessage = "Informe o Id.")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome de município é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome de Municipio deve ter no máximo {1] caracteres.")]
        public string Nome { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido.")]
        public int CodIbge { get; set; }
        [Required(ErrorMessage = "Uf é campo obrigatório.")]
        public Guid UfId { get; set; }
    }
}
