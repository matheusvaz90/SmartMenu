using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do produto é obrigatório")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "A descrição do produto é obrigatória")]
        public string Descricao { get; set; } = string.Empty;
        [Required(ErrorMessage = "O preço base é obrigatório")]
        [Range(0.01, 10000, ErrorMessage = "O preço base deve ser maior que zero")]
        public decimal PrecoBase { get; set; }
        public bool Ativo { get; set; } = true;

        public List<ProdutoReceita> Receita { get; set; } = new();
    }
}