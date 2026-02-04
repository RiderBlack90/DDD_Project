using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces;
public interface GenericInterfaceApp<T> where T : class
{
    Task Add(T Object);
    Task Update(T Object);
    Task Delete(T Object);
    Task<T> GetEntityById(int id);
    Task<List<T>> List();

}
