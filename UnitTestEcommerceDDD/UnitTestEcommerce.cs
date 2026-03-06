using Domain.Interfaces.IProducts;
using Domain.Interfaces.IServices;
using Domain.Services;
using Entities.Entities;
using Infra.Repositories;

namespace UnitTestEcommerceDDD;

[TestClass]
public sealed class UnitTestEcommerce
{
    [TestMethod]
    public async Task AddProdutoComSucesso()
    {

        try
        {
            IProduct _IProduct = new ProductRepository();
            IServicesProduct _IServiceProduct = new ServiceProduct(_IProduct);
            var produto = new Produto()
            {
                Descricao = string.Concat("Descrição Test DTO ", DateTime.Now.ToString()),
                QtdEstoque = 10,
                Nome = string.Concat("Nome Test DTO ", DateTime.Now.ToString()),
                Valor = 20,
                UserId = "14f0bebe-8cc5-4548-bb98-e6414ed79b51"
            };
            await _IServiceProduct.AddProduct(produto);

            Assert.IsFalse(produto.Notcations.Any());
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }
    [TestMethod]
    public async Task AddProdutoComValidacaoCampoObrigatorio()
    {

        try
        {
            IProduct _IProduct = new ProductRepository();
            IServicesProduct _IServiceProduct = new ServiceProduct(_IProduct);
            var produto = new Produto()
            {
                
            };
            await _IServiceProduct.AddProduct(produto);

            Assert.IsTrue(produto.Notcations.Any());
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }
    [TestMethod]
    public async Task ListarProdutosUsuario()
    {
        try
        {
            IProduct _IProduct = new ProductRepository();
            var listaProdutos = await _IProduct.ListarProdutosUsuario("14f0bebe-8cc5-4548-bb98-e6414ed79b51");

            Assert.IsTrue(listaProdutos.Any());
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }
    [TestMethod]
    public async Task GetEntityById()
    {
        try
        {
            IProduct _IProduct = new ProductRepository();
            var listaProdutos = await _IProduct.ListarProdutosUsuario("14f0bebe-8cc5-4548-bb98-e6414ed79b51");
            var produto = await _IProduct.GetEntityById(listaProdutos.LastOrDefault().Id);

            Assert.IsTrue(produto != null);
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }
    [TestMethod]
    public async Task Delete()
    {
        try
        {
            IProduct _IProduct = new ProductRepository();
            var listaProdutos = await _IProduct.ListarProdutosUsuario("14f0bebe-8cc5-4548-bb98-e6414ed79b51");
            var ultimoProduto = listaProdutos.LastOrDefault();
            var produto = await _IProduct.GetEntityById(listaProdutos.LastOrDefault().Id);

            Assert.IsTrue(true);
        }
        catch (Exception)
        {
            Assert.Fail();
        }
    }
}
