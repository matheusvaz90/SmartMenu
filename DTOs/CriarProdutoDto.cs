using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.DTOs
{
    public class CriarProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal PrecoBase { get; set; }
        public bool Ativo { get; set; } = true;
    }
}