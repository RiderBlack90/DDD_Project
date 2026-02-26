using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IProducts;
public interface IProduct : IGeneric<Produto>
{
    Task<List<Produto>> ListarProdutosUsuario(string userId);
}

