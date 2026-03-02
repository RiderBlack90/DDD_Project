using Application.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web_ECommerce.Controllers;

[Authorize]
public class ProductsController : Controller
{
    public readonly InterfaceProductApp _IProductApp;
    public readonly UserManager<ApplicationUser> _userManager;
    public readonly InterfaceCompraUsuarioApp _ICompraUsuarioApp;
    public ProductsController(InterfaceProductApp interfaceProductApp , UserManager<ApplicationUser> userManager, InterfaceCompraUsuarioApp ICompraUsuarioApp)
    {
        _IProductApp = interfaceProductApp;
        _userManager = userManager;
        _ICompraUsuarioApp = ICompraUsuarioApp;
    }
    // GET: ProductsController
    public async Task<IActionResult> Index()
    {
        var idUsuario = await RetornarIdUsuarioLogado();



        return View(await _IProductApp.ListarProdutosUsuario(idUsuario));
    }

    // GET: ProductsController/Details/5ff
    public async Task<IActionResult> Details(int id)
    {
        return View(await _IProductApp.GetEntityById(id));
    }

    // GET: ProductsController/Create
    public async Task<IActionResult> Create()
    {
        return View();
    }

    // POST: ProductsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Produto produto)
    {
        try
        {
            var idUsuario = await RetornarIdUsuarioLogado();
            produto.UserId = idUsuario;

            await _IProductApp.AddProduct(produto);
            if (produto.Notcations.Any())
            {
                foreach (var item in produto.Notcations)
                {
                    ModelState.AddModelError(item.PropertyName, item.mensagem);
                }
                return View("Create", produto);
            }


        }
        catch
        {
            return View("Create", produto);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: ProductsController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        return View(await _IProductApp.GetEntityById(id));
    }

    // POST: ProductsController/Edit/50
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> EditAsync(int id, Produto produto)
    {
        try
        {
            await _IProductApp.UpdateProduct(produto);
            if (produto.Notcations.Any())
            {
                foreach (var item in produto.Notcations)
                {
                    ModelState.AddModelError(item.PropertyName, item.mensagem);
                }

                ViewBag.Alerta = true;
                ViewBag.Mensagem = "Ocorreu algum erro, verifique!";
                return View("Edit", produto);
            }


        }
        catch
        {
            return View("Edit", produto);
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: ProductsController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        return View(await _IProductApp.GetEntityById(id));
    }

    // POST: ProductsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, Produto produto)
    {
        try
        {
            var produtoDelete = await _IProductApp.GetEntityById(id);
            await _IProductApp.Delete(produto);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    private async Task<string> RetornarIdUsuarioLogado()
    {
        var idUsuario = await _userManager.GetUserAsync(User);
        return idUsuario.Id;
    }

    [AllowAnonymous]
    [HttpGet("/api/ListarProdutosComEstoque")]
    public async Task<JsonResult> ListarProdutosComEstoque()
    {
        return Json(await _IProductApp.ListarProdutosComEstoque());
    }

    public async Task<IActionResult> ListarProdutosCarrinhoUsuario()
    {
        var idUsuario = await RetornarIdUsuarioLogado();
        return View(await _IProductApp.ListarProdutosCarrinhoUsuario(idUsuario));
    }


    // GET: ProductsController/Delete/5
    public async Task<IActionResult> RemoverCarrinho(int id)
    {
        return View(await _IProductApp.ObterProdutoCarrinho(id));
    }

    // POST: ProductsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoverCarrinho(int id, Produto produto)
    {
        try
        {
            var produtoDelete = await _ICompraUsuarioApp.GetEntityById(id);
            await _ICompraUsuarioApp.Delete(produtoDelete);
            return RedirectToAction(nameof(ListarProdutosCarrinhoUsuario));
        }
        catch
        {
            return View();
        }
    }
}
