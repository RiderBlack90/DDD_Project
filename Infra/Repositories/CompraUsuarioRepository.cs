using Domain.Interfaces.ICompraUser;
using Entities.Entities;
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
    public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
    {
        using (var banco = new ContextBase(_optionsbuilder))
        {
            return await banco.ComprasUsuario
                .Where(c => c.UserId == userId)
                .CountAsync();
        }
    }

}
