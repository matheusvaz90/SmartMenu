using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.Models
{
    public class Ingrediente
    {
        [Required(ErrorMessage = "O id do ingrediente é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do ingrediente é obrigatório")]
        public string Nome { get; set; } = string.Empty;
        public decimal EstoqueAtual { get; set; }

        [Required(ErrorMessage = "A quantidade dos ingredientes é obrigatória")]
        [Range(1,1000, ErrorMessage  = "A quantidade tem que ser maior que zero")]
        public string Unidade { get; set; } = "UN";
        public decimal PrecoAdicional { get; set; }
    }
}