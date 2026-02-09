using Domain.Interfaces.IProducts;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services;
public class ServiceProduct : IServicesProduct
{
    private readonly IProduct _Iproduct;
    public ServiceProduct(IProduct IProduct)
    {
        _Iproduct = IProduct;
    }
    public async Task AddProduct(Produto produto)
    {
        var ValidateName = produto.ValidateStringProperty(produto.Nome, "Nome");
        var ValidateValue = produto.ValidateDecimalValue(produto.Valor, "Valor");

        if (ValidateName && ValidateValue)
        {
            produto.Estado = true;
            await _Iproduct.Add(produto);
        }

    }

    public async Task UpdateProduct(Produto produto)
    {

        var ValidateName = produto.ValidateStringProperty(produto.Nome, "Nome");
        var ValidateValue = produto.ValidateDecimalValue(produto.Valor, "Valor");

        if (ValidateName && ValidateValue)
        { 
            await _Iproduct.Update(produto);
        }
    }
}
