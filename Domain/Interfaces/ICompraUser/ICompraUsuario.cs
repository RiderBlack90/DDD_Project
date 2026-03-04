using Domain.Interfaces.Generics;
using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.ICompraUser;

public interface ICompraUsuario : IGeneric<CompraUsuario>
{
    Task<int> QuantidadeProdutoCarrinhoUsuario(string userId);

    Task<CompraUsuario> ProdutosCompradosPorEstado(string userId, EnumBoughtState estado);
    Task<bool> ConfirmaCompraCarrinhoUsuario(string userId);
}
