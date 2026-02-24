using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SmartMenu.Api.Models;

namespace SmartMenu.Api.DTOs
{
    public class AtualizaStatusDto
    {
        public StatusPedido NovoStatus { get; set; }
    }
}