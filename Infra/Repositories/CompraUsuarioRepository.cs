using Domain.Interfaces.ICompraUser;
using Entities.Entities;
using Entities.Entities.Enums;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositories;

public class CompraUsuarioRepository : GenericRepository<CompraUsuario> , ICompraUsuario
{
    private readonly DbContextOptions<ContextBase> _optionsbuilder;

    public CompraUsuarioRepository()
    {
        _optionsbuilder = new DbContextOptions<ContextBase>();
    }

    public async Task<bool> ConfirmaCompraCarrinhoUsuario(string userId)
    {
        try
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var compraUsuario = new CompraUsuario();
                compraUsuario.ListaProdutos = new List<Produto>();

                var produtosCarrinhoUsuario = await (from p in banco.Produto
                                                     join c in banco.ComprasUsuario on p.Id equals c.ProdutoId
                                                     where c.UserId.Equals(userId) && c.Estado == EnumBoughtState.Carrinho
                                                     select c).AsNoTracking().ToListAsync();

                produtosCarrinhoUsuario.ForEach(p =>
                {
                    p.Estado = EnumBoughtState.Comprado;
                });

                banco.UpdateRange(produtosCarrinhoUsuario);
                await banco.SaveChangesAsync();

                return true;
            }
        }
        catch (Exception erro)
        {
            return false;
        }
    }
    

    public async Task<CompraUsuario> ProdutosCompradosPorEstado(string userId, EnumBoughtState estado)
    {
        using(var banco = new ContextBase(_optionsbuilder))
        {
            var compraUsuario = new CompraUsuario();
            compraUsuario.ListaProdutos = new List<Produto>();

            var produtosCarrinhoUsuario = await (from p in banco.Produto
                                                 join c in banco.ComprasUsuario on p.Id equals c.ProdutoId
                                                 where c.UserId.Equals(userId) && c.Estado == estado
                                                 select new Produto
                                                 {
                                                     Id = p.Id,
                                                     Nome = p.Nome,
                                                     Descricao = p.Descricao,
                                                     Observacao = p.Observacao,
                                                     Valor = p.Valor,
                                                     QtdCompra = c.QtdCompra,
                                                     IdProdutoCarrinho = c.Id,
                                                     Url = p.Url,
                                                 }).AsNoTracking().ToListAsync();

            compraUsuario.ListaProdutos = produtosCarrinhoUsuario;
            compraUsuario.ApplicationUser = await banco.ApplicationUser.FirstOrDefaultAsync(u => u.Id.Equals(userId));
            compraUsuario.QuantidadeProdutos = produtosCarrinhoUsuario.Count();
            compraUsuario.EnderecoCompleto = string.Concat(compraUsuario.ApplicationUser.Endereco, " - ", compraUsuario.ApplicationUser.CompEndereco, " - CEP: ", compraUsuario.ApplicationUser.CEP);
            compraUsuario.ValorTotal = produtosCarrinhoUsuario.Sum(v => v.Valor);
            compraUsuario.Estado = estado;
            return compraUsuario;
        }
    }
    
    public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
    {
        using (var banco = new ContextBase(_optionsbuilder))
        {
            return await banco.ComprasUsuario.CountAsync(c => c.UserId == userId && c.Estado == EnumBoughtState.Carrinho);
        }
    }

}
