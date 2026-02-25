using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infra.Configuration;

public class ContextBase : IdentityDbContext<ApplicationUser>
{
    public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<CompraUsuario> ComprasUsuario { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
