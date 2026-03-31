using System.ComponentModel.DataAnnotations;
namespace SmartMenu.Api.Models
{
    public class PedidoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID do pedido é obrigatório ")]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;

        [Required(ErrorMessage = "O ID do produto é obrigatório")]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;

        [Required(ErrorMessage = "A quantidade do item é obrigatória")]
        [Range(1, 1000, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public List<PedidoItemModificacao> Modificacoes { get; set; } = new();

    }

}