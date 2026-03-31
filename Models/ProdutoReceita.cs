using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.Models
{
    public class ProdutoReceita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID do produto é obrigatório ")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;

        [Required(ErrorMessage = "O ingrediente é obrigatório ")]
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; } = null!;

        [Required(ErrorMessage = "A quantidade necessária é obrigatória")]
        [Range(0.01, 1000, ErrorMessage = "A quantidade deve ser maior que zero")]
        public decimal QuantidadeNecessaria { get; set; }
    }
}