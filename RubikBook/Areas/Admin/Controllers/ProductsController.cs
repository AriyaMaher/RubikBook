using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using RubikBook.Core.Interface;
using RubikBook.Database.Models;
using RubikBook.Database.Context;

namespace RubikBook.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductsController : Controller
{
    IProduct _product;
    IGroup _group;
    IAuthor _author;
    IPublisher _publisher;
    public ProductsController(IProduct product, IGroup group, IAuthor author, IPublisher publisher)
    {
        _product = product;
        _group = group;
        _author = author;
        _publisher = publisher;
    }

    public async Task<IActionResult> Index(string searchString = null)
    {
        var products = await _product.GetProducts();
        if (!string.IsNullOrEmpty(searchString))
        {
            var products1 = await _product.GetProducts(searchName:searchString);
            return View(products1);
        }
        return View(products);
    }


    public async Task<IActionResult> Create()
    {
        ViewBag.GroupId = new SelectList(await _group.GetGroups(), "Id", "GroupName");
        ViewBag.AuthorId = new SelectList(await _author.GetAuthors(), "Id", "AuthorName");
        ViewBag.PublisherId = new SelectList(await _publisher.GetPublishers(), "Id", "PublisherName");

        ViewBag.ProductId = Guid.NewGuid();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product , IFormFile productImg)
    {
        if (ModelState.IsValid && productImg!=null)
        {
            if (await _product.AddProduct(product, productImg))
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("img", "خطا در ثبت محصول");
        }
        ViewBag.GroupId = new SelectList(await _group.GetGroups(), "Id", "GroupName");
        ViewBag.AuthorId = new SelectList(await _author.GetAuthors(), "Id", "AuthorName");
        ViewBag.Publisher = new SelectList(await _publisher.GetPublishers(), "Id", "PublisherName");
        ViewBag.ProductId = Guid.NewGuid();
        return View(product);
    }

    public async Task<IActionResult> Details(Guid id) {

        var product = await _product.GetProduct(id);
        ViewBag.GroupId = (await _group.GetGroups(), "Id", "GroupName");
        ViewBag.AuthorId = (await _author.GetAuthors(), "Id", "AuthorName");
        ViewBag.PublisherId = (await _publisher.GetPublishers(), "Id", "PublisherName");
        if (product != null)
        {
            return View(product);
        }
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _product.GetProduct(id);
        if (product == null)
        {
            return RedirectToAction(nameof(Index));
        }
        return PartialView(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
	public async Task<IActionResult> Delete(Product product)
    {
        await _product.DeleteProduct(product);
        return RedirectToAction(nameof(Index));
    }


	public async Task<IActionResult> Edit(Guid id)
    {
        var product = await _product.GetProduct(id);
        ViewBag.GroupId = new SelectList(await _group.GetGroups(), "Id", "GroupName");
        ViewBag.AuthorId = new SelectList(await _author.GetAuthors(), "Id", "AuthorName");
        ViewBag.PublisherId = new SelectList(await _publisher.GetPublishers(), "Id", "PublisherName");
        if (product != null)
        {
            return View(product);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Product product, IFormFile productImg)
    {        
		if (ModelState.IsValid)
        {
            if (await _product.EditProduct(product,productImg))
            {   
				return RedirectToAction(nameof(Details));
			}
        }
        ModelState.AddModelError("img","خطا در ادیت محصول" );
        return View(product);
    }


}
