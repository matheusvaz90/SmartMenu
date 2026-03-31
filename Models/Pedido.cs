using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SmartMenu.Api.Models
{
    public enum StatusPedido
    {
        Pendente = 1,
        EmPreparo = 2,
        Pronto = 3,
        Entregue = 4,
        Cancelado = 5
    }

    public class Pedido
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O número da mesa é obrigatório")]
        [Range(1, 100, ErrorMessage = "O número da mesa deve ser maior que zero")]
        public int NumeroMesa { get; set; }
        public DateTime DataHora { get; set; }
        public StatusPedido Status { get; set; } = StatusPedido.Pendente;
        [Required(ErrorMessage = "O DeviceId é obrigatório")]
        public string DeviceId { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }

        public List<PedidoItem> Itens { get; set; } = new();
    }
}