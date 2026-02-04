using Domain.Interfaces.IProducts;
using Entities.Entities;
using Infra.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories;

public class ProductRepository : GenericRepository<Produto>, IProduct
{
}
