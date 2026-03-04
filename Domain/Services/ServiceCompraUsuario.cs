using Domain.Interfaces.ICompraUser;
using Domain.Interfaces.IServices;
using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services;

public class ServiceCompraUsuario : IServiceCompraUsuario
{
    private readonly ICompraUsuario _ICompraUsuario;
    public ServiceCompraUsuario(ICompraUsuario ICompraUsuario)
    {
        _ICompraUsuario = ICompraUsuario;
    }


    public async Task<CompraUsuario> CarrinhoCompras(string userId)
    {
        return await _ICompraUsuario.ProdutosCompradosPorEstado(userId, EnumBoughtState.Carrinho);
    }

    public async Task<CompraUsuario> ProdutosComprados(string userId)
    {
        return await _ICompraUsuario.ProdutosCompradosPorEstado(userId, EnumBoughtState.Comprado);
    }
}
