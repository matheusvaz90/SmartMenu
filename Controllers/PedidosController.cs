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
    [ApiController]                         // ⬅️ 1. Decorador
    [Route("api/[controller]")]             // ⬅️ 2. Define URL

    public class PedidosController : ControllerBase
    {

        private readonly AppDbContext _context;  // ⬅️ 4. Declara o context

        public PedidosController(AppDbContext context)  // ⬅️ 5. Construtor
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            {
                var pedido = await _context.Pedidos
        .Include(p => p.Itens)  // ⬅️ Carrega os itens junto
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
    }
}