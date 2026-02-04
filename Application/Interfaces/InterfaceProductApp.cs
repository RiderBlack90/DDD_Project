using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface InterfaceProductApp : GenericInterfaceApp<Produto>
{
    Task EditProduct(Produto produto);

    Task UpdateProduct(Produto produto);
}
