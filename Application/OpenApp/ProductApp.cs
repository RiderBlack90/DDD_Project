using Application.Interfaces;
using Domain.Interfaces.IProducts;
using Domain.Interfaces.IServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.OpenApp;
public class ProductApp : InterfaceProductApp
{
    IProduct _IProduct;
    IServicesProduct _IServicesProduct;

    public ProductApp(IProduct Iproduct, IServicesProduct IservicesProduct)
    {
        _IProduct = Iproduct;
        _IServicesProduct = IservicesProduct;

    }
    public async Task Add(Produto Object)
    {
        await _IProduct.Add(Object);
    }

    public async Task Delete(Produto Object)
    {
        await _IProduct.Delete(Object);
    }

    public async Task<Produto> GetEntityById(int id)
    {
        return await _IProduct.GetEntityById(id);
    }

    public async Task<List<Produto>> List()
    {
        return await _IProduct.List();
    }

    public async Task Update(Produto Object)
    {
        await _IProduct.Update(Object);
    }

    public async Task UpdateProduct(Produto produto)
    {
        await _IServicesProduct.UpdateProduct(produto);
    }
    public async Task AddProduct(Produto produto)
    {
        await _IServicesProduct.AddProduct(produto);
    }

    public async Task<List<Produto>> ListarProdutosUsuario(string userId)
    {
        return await _IProduct.ListarProdutosUsuario(userId);
    }

    public async Task<List<Produto>> ListarProdutosComEstoque()
    {
        return await _IServicesProduct.ListarProdutosComEstoque();
    }

    public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
    {
        return await _IProduct.ListarProdutosCarrinhoUsuario(userId);
    }

    public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
    {
        return await _IProduct.ObterProdutoCarrinho(idProdutoCarrinho);
    }
}
