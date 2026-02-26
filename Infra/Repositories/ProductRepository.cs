using Domain.Interfaces.IProducts;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories;

public class ProductRepository : GenericRepository<Produto>, IProduct
{
    private readonly DbContextOptions<ContextBase> _optionsbuilder;

    public ProductRepository()
    {
        _optionsbuilder = new DbContextOptions<ContextBase>();
    }

    public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto)
    {

        using (var banco = new ContextBase(_optionsbuilder))
        {
            return await banco.Produtos.Where(exProduto).AsNoTracking().ToListAsync();
        }
    }

    public async Task<List<Produto>> ListarProdutosUsuario(string userId)
    {
        using (var banco = new ContextBase(_optionsbuilder))
        {
            return await banco.Produtos.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
        }
    }

}
