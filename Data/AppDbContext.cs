using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartMenu.Api.Models;

namespace SmartMenu.Api.Data;

public class AppDbContext : DbContext

{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ProdutoReceita> ProdutoReceitas { get; set; }

    public DbSet<PedidoItemModificacao> Modificacoes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoItem> PedidoItens { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ingrediente>()
            .Property(i => i.PrecoAdicional)
            .HasConversion<double>();
    }
}
