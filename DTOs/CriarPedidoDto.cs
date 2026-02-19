using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.DTOs
{
    public class CriarPedidoDto
    {
        public int NumeroMesa { get; set; }
        public string DeviceId { get; set; } = string.Empty;
        public List<CriarPedidoItemDto> Itens { get; set; } = new();
    }
}