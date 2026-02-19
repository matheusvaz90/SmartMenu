using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal EstoqueAtual { get; set; }
        public string Unidade { get; set; } = "UN";
        public decimal PrecoAdicional { get; set; }
    }
}