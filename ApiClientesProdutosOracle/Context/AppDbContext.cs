using ApiClientesProdutosOracle.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiClientesProdutosOracle.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options ) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }

}
