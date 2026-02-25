using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMenu.Api.Data;
using SmartMenu.Api.DTOs;
using SmartMenu.Api.Models;

namespace SmartMenu.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoCardapioDto>>> GetProdutos()
        {

            var produtos = await _context.Produtos
                .Where(p => p.Ativo)
                .Include(p => p.Receita)
                    .ThenInclude(r => r.Ingrediente)
                .ToListAsync();

            var produtosDisponiveis = produtos
                .Where(p => p.Receita.Any() &&
                            p.Receita.All(r => r.Ingrediente.EstoqueAtual >= r.QuantidadeNecessaria))
                .ToList();

            var cardapio = produtosDisponiveis
                .Select(p => new ProdutoCardapioDto
                {
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    PrecoBase = p.PrecoBase
                })
                .ToList();

            return cardapio;
        }

        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetTodosProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound();

            return produto;
        }

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