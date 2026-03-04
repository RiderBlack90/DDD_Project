using Application.Interfaces;
using Domain.Interfaces.ICompraUser;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OpenApp;

public class CompraUsuarioApp : InterfaceCompraUsuarioApp
{
    private readonly ICompraUsuario _ICompraUsuario;
    private readonly IServiceCompraUsuario _IServiceCompraUsuario;
    public CompraUsuarioApp(ICompraUsuario CompraUsuario, IServiceCompraUsuario IServiceCompraUsuario)
    {
        _ICompraUsuario = CompraUsuario;
        _IServiceCompraUsuario = IServiceCompraUsuario;
    }
    public async Task Add(CompraUsuario Object)
    {
        await _ICompraUsuario.Add(Object);
    }

    public async Task Delete(CompraUsuario Object)
    {
        await _ICompraUsuario.Delete(Object);
    }

    public async Task<CompraUsuario> GetEntityById(int id)
    {
        return await _ICompraUsuario.GetEntityById(id);
    }

    public async Task<List<CompraUsuario>> List()
    {
        return await _ICompraUsuario.List();
    }
    public async Task Update(CompraUsuario Object)
    {
        await _ICompraUsuario.Update(Object);
    }
    public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
    {
        return await _ICompraUsuario.QuantidadeProdutoCarrinhoUsuario(userId);
    }

    public async Task<CompraUsuario> CarrinhoCompras(string userId)
    {
        return await _IServiceCompraUsuario.CarrinhoCompras(userId);
    }

    public async Task<CompraUsuario> ProdutosComprados(string userId)
    {
       return await _IServiceCompraUsuario.ProdutosComprados(userId);
    }

    public async Task<bool> ConfirmaCompraCarrinhoUsuario(string userId)
    {
        return await _ICompraUsuario.ConfirmaCompraCarrinhoUsuario(userId);
    }
}
