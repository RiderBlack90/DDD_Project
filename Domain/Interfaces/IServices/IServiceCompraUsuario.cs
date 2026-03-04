using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.IServices;

public interface IServiceCompraUsuario
{
    public Task<CompraUsuario> CarrinhoCompras(string userId);
    public Task<CompraUsuario> ProdutosComprados (string userId);
}
