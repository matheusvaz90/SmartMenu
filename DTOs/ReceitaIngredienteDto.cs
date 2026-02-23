using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMenu.Api.DTOs
{
    public class ReceitaIngredienteDto
    {
        public int IngredienteId { get; set; }

        public decimal Quantidade { get; set; }
    }
}