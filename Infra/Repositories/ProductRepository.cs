using Domain.Interfaces.IProducts;
using Entities.Entities;
using Entities.Entities.Enums;
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
            return await banco.Produto.Where(exProduto).AsNoTracking().ToListAsync();
        }
    }

    public async Task<List<Produto>> ListarProdutosUsuario(string userId)
    {
        using (var banco = new ContextBase(_optionsbuilder))
        {
            return await banco.Produto.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
        }
    }

    public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
    {
        using (var banco = new ContextBase(_optionsbuilder))
        {
            var produtosCarrinhoUsuario = await (from p in banco.Produto
                                                 join c in banco.ComprasUsuario on p.Id equals c.ProdutoId
                                                 where c.Id.Equals(idProdutoCarrinho) && c.Estado == EnumBoughtState.Carrinho
                                                 select new Produto
                                                 {
                                                     Id = p.Id,
                                                     Nome = p.Nome,
                                                     Descricao = p.Descricao,
                                                     Observacao = p.Observacao,
                                                     Valor = p.Valor,
                                                     QtdCompra = c.QtdCompra,
                                                     IdProdutoCarrinho = c.Id

                                                 }).AsNoTracking().FirstOrDefaultAsync();
            return produtosCarrinhoUsuario;
        }
    }

    public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
    {
        using (var banco = new ContextBase(_optionsbuilder))
        {
            var produtosCarrinhoUsuario = await (from p in banco.Produto
                                          join c in banco.ComprasUsuario on p.Id equals c.ProdutoId
                                          where c.UserId.Equals(userId) && c.Estado == EnumBoughtState.Carrinho
                                          select new Produto
                                          {
                                              Id = p.Id,
                                              Nome = p.Nome,
                                              Descricao = p.Descricao,
                                              Observacao = p.Observacao,
                                              Valor = p.Valor,
                                              QtdCompra = c.QtdCompra,
                                              IdProdutoCarrinho = c.Id
                                              
                                          }).AsNoTracking().ToListAsync();
            return produtosCarrinhoUsuario;
        }
    }
}
