using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreinaWeb.MinhaAPI.API.HATEOAS;

namespace TreinaWeb.MinhaAPI.API.DTO
{
    public class AlunoDTO : RestResource
    {   
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do aluno é obrigatorio")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage ="Maximo de 20 caracters")]
        public string Nome { get; set; }
        [MaxLength(100, ErrorMessage ="Maximo de 100 caracteres")]
        public string Endereco { get; set; }
        [Required(ErrorMessage ="Mensalidade obrigatoria")]
        [Range(0.01, 9999.99, ErrorMessage = "Valor da mensalidade é entre 0.01 - 9999.99")]
        public decimal Mensalidade { get; set; }
    }
}