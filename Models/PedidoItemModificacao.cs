using System;
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

        public int PedidoItemId { get; set; }
        public PedidoItem PedidoItem { get; set; } = null!;

        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; } = null!;

        public TipoModificacao Tipo { get; set; }

        public decimal PrecoAdicional { get; set; }
    }
}