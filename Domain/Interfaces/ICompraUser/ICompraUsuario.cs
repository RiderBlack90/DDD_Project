using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.ICompraUser;

public interface ICompraUsuario : IGeneric<CompraUsuario>
{
    Task<int> QuantidadeProdutoCarrinhoUsuario(string userId);

}
