using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;

namespace Infra.Configuration;

public class ContextBase : IdentityDbContext<ApplicationUser>
{
    public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<CompraUsuario> ComprasUsuario => Set<CompraUsuario>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<CompraUsuario>(entity =>
        {
            entity.HasOne(x => x.Produto)
                  .WithMany() 
                  .HasForeignKey(x => x.ProdutoId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.ApplicationUser)
                  .WithMany() 
                  .HasForeignKey(x => x.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
