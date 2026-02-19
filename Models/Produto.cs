using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal PrecoBase { get; set; }
        public bool Ativo { get; set; } = true;

        public List<ProdutoReceita> Receita { get; set; } = new();
    }
}