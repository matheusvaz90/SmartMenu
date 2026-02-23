using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMenu.Api.Data;
using SmartMenu.Api.DTOs;
using SmartMenu.Api.Models;

namespace SmartMenu.Api.Controllers
{
    [ApiController]                         // ⬅️ 1. Decorador
    [Route("api/[controller]")]             // ⬅️ 2. Define URL
    public class ProdutoController : ControllerBase  // ⬅️ 3. Herda de ControllerBase
    {
        private readonly AppDbContext _context;  // ⬅️ 4. Declara o context

        public ProdutoController(AppDbContext context)  // ⬅️ 5. Construtor
        {
            _context = context;
        }

        // GET: api/produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound();

            return produto;
        }

        // POST: api/produto
        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduto(CriarProdutoDto dto)
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                PrecoBase = dto.PrecoBase,
                Ativo = dto.Ativo
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPost("{id}/receita")]
        public async Task<ActionResult> AdicionarReceita(int id, AdicionarReceitaDto dto)
        {
            var produto = await _context.Produtos
                .Include(p => p.Receita)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (produto == null)
                return NotFound("Produto não encontrado");

            foreach (var ingredienteDto in dto.Ingredientes)
            {
                var ingrediente = await _context.Ingredientes.FindAsync(ingredienteDto.IngredienteId);

                if (ingrediente == null)
                    return BadRequest($"Ingrediente {ingredienteDto.IngredienteId} não encontrado");

                var receitaItem = new ProdutoReceita
                {
                    ProdutoId = produto.Id,
                    IngredienteId = ingredienteDto.IngredienteId,
                    QuantidadeNecessaria = ingredienteDto.Quantidade
                };

                produto.Receita.Add(receitaItem);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}