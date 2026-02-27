using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces;


public interface InterfaceCompraUsuarioApp : IGeneric<CompraUsuario>
{
    public Task<int> QuantidadeProdutoCarrinhoUsuario(string userId);

}
