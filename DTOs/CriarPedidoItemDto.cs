using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.DTOs
{
    public class CriarPedidoItemDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}