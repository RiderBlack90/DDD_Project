using Application.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_ECommerce.Controllers;

public class ProductsController : Controller
{
    public readonly InterfaceProductApp _IProductApp;
    public ProductsController(InterfaceProductApp interfaceProductApp)
    {
        _IProductApp = interfaceProductApp; 
    }
    // GET: ProductsController
    public async Task<IActionResult> Index()
    {
        return View(await _IProductApp.List());
    }

    // GET: ProductsController/Details/5
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
            await _IProductApp.EditProduct(produto);
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

    // POST: ProductsController/Edit/5
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
            var produtoDelete= await _IProductApp.GetEntityById(id);
            await _IProductApp.Delete(produto);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
