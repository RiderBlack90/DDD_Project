using Domain.Interfaces.IProducts;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        var ValidateStock = produto.ValidateIntProperty(produto.QtdEstoque, "QtdEstoque");

        if (ValidateName && ValidateValue && ValidateStock)
        {
            produto.DataCadastro = DateTime.Now;
            produto.DataAlteracao= DateTime.Now;
            produto.Estado = true;
            await _Iproduct.Add(produto);
        }

    }

    public async Task<List<Produto>> ListarProdutosComEstoque(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
        return await _Iproduct.ListarProdutos(p => p.QtdEstoque > 0);
        else
        {
            return await _Iproduct.ListarProdutos(p => p.QtdEstoque > 0 && p.Nome.ToUpper().Contains(descricao.ToUpper()));
        }
    }

    public async Task UpdateProduct(Produto produto)
    {

        var ValidateName = produto.ValidateStringProperty(produto.Nome, "Nome");
        var ValidateValue = produto.ValidateDecimalValue(produto.Valor, "Valor");
        var ValidateStock = produto.ValidateIntProperty(produto.QtdEstoque, "QtdEstoque");

        if (ValidateName && ValidateValue && ValidateStock)
        {
            produto.DataAlteracao = DateTime.Now;
            await _Iproduct.Update(produto);
        }
    }
}
