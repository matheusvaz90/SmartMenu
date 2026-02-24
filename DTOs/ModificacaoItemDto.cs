using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMenu.Api.Models;

namespace SmartMenu.Api.DTOs
{
    public class ModificacaoItemDto
    {
        public int IngredienteId { get; set; }
        public TipoModificacao Tipo { get; set; }
    }
}