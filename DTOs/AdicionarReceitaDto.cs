using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.DTOs
{
    public class AdicionarReceitaDto
    {
        public List<ReceitaIngredienteDto> Ingredientes { get; set; } = new();
    }
}