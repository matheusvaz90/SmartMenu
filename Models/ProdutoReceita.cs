using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.Models
{
    public class ProdutoReceita
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;

        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; } = null!;

        public decimal QuantidadeNecessaria { get; set; }
    }
}