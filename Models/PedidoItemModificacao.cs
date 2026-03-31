using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.Models
{
    public enum TipoModificacao
    {
        Adicionar = 1,
        Remover = 2
    }

    public class PedidoItemModificacao
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O ID do pedido é obrigatório")]
        public int PedidoItemId { get; set; }
        public PedidoItem PedidoItem { get; set; } = null!;

        [Required(ErrorMessage = "O ingrediente adicional é obrigatório")]
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; } = null!;

        [Required(ErrorMessage = "O tipo de modificação é obrigatório")]
        public TipoModificacao Tipo { get; set; }

        public decimal PrecoAdicional { get; set; }
    }
}