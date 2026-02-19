using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMenu.Api.Data;
using SmartMenu.Api.DTOs;
using SmartMenu.Api.Models;

namespace SmartMenu.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ingredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
        {
            return await _context.Ingredientes.ToListAsync();
        }

        // GET: api/ingredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return ingrediente;
        }

        // POST: api/ingredientes
        [HttpPost]
        public async Task<ActionResult<Ingrediente>> CreateIngrediente(CriarIngredienteDto dto)
        {
            var ingrediente = new Ingrediente
            {
                Nome = dto.Nome,
                EstoqueAtual = dto.EstoqueAtual,
                Unidade = dto.Unidade,
                PrecoAdicional = dto.PrecoAdicional
            };

            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIngrediente), new { id = ingrediente.Id }, ingrediente);
        }

        // PUT: api/ingredientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngrediente(int id, CriarIngredienteDto dto)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            ingrediente.Nome = dto.Nome;
            ingrediente.EstoqueAtual = dto.EstoqueAtual;
            ingrediente.Unidade = dto.Unidade;
            ingrediente.PrecoAdicional = dto.PrecoAdicional;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ingredientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngrediente(int id)
        {
            var ingrediente = await _context.Ingredientes.FindAsync(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            _context.Ingredientes.Remove(ingrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
