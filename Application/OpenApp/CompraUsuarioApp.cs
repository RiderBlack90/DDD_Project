using Application.Interfaces;
using Domain.Interfaces.ICompraUser;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.OpenApp;

public class CompraUsuarioApp : InterfaceCompraUsuarioApp
{
    private readonly ICompraUsuario _ICompraUsuario;
    public CompraUsuarioApp(ICompraUsuario CompraUsuario)
    {
        _ICompraUsuario = CompraUsuario;
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
}
