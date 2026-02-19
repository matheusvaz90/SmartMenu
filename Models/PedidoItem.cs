namespace SmartMenu.Api.Models
{
    public class PedidoItem
    {
        public int Id { get; set; }

        // Chave estrangeira para Pedido
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;

        // Chave estrangeira para Produto
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;

        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}