using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMenu.Api.Data;
using SmartMenu.Api.DTOs;
using SmartMenu.Api.Models;

namespace SmartMenu.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PedidosController : ControllerBase
    {

        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            {
                var pedido = await _context.Pedidos
        .Include(p => p.Itens)
        .FirstOrDefaultAsync(p => p.Id == id);

                if (pedido == null)
                    return NotFound();

                return pedido;
            }

        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CreatePedido(CriarPedidoDto dto)
        {
            var pedido = new Pedido
            {
                NumeroMesa = dto.NumeroMesa,
                DeviceId = dto.DeviceId,
                DataHora = DateTime.Now,
                Status = StatusPedido.Pendente,
                ValorTotal = 0
            };

            foreach (var itemDto in dto.Itens)
            {
                var produto = await _context.Produtos.FindAsync(itemDto.ProdutoId);

                if (produto == null)
                    return BadRequest($"Produto {itemDto.ProdutoId} não encontrado");

                var item = new PedidoItem
                {
                    ProdutoId = itemDto.ProdutoId,
                    Quantidade = itemDto.Quantidade,
                    PrecoUnitario = produto.PrecoBase
                };

                pedido.Itens.Add(item);

                pedido.ValorTotal += itemDto.Quantidade * produto.PrecoBase;
            }

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id }, pedido);


        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> AtualizarStatus(int id, AtualizaStatusDto dto)
        {
            var pedido = await _context.Pedidos
        .Include(p => p.Itens)
            .ThenInclude(i => i.Produto)
                .ThenInclude(pr => pr.Receita)
                    .ThenInclude(r => r.Ingrediente)
        .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            pedido.Status = dto.NovoStatus;

            if (dto.NovoStatus == StatusPedido.Entregue)
            {
                foreach (var item in pedido.Itens)
                {
                    foreach (var receita in item.Produto.Receita)
                    {
                        receita.Ingrediente.EstoqueAtual -= receita.QuantidadeNecessaria * item.Quantidade;
                    }
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}