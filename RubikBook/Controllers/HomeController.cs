using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;
using RubikBook.Core.ViewModels;
using RubikBook.Database.Models;

namespace RubikBook.Controllers;

public class HomeController : Controller
{

	IGroup _group;
	IProduct _product;
	public HomeController(IGroup group, IProduct product)
	{
		_group = group;
		_product = product;
	}

	public async Task<IActionResult> Index()
	{
		var groups = await _group.GetGroups(notShow: false);
		var products = (await _product.GetProducts(notShow:false)).Take(8);
		var productSF = (await _product.GetProducts(notShow: false, sellOff: 1)).Take(4);
		AllViewModel allViewModel = new AllViewModel()
		{
			Groups = groups,
			Products = products,
			ProductsSellOff = productSF,
		};
		return View(allViewModel);
	}



	public async Task<IActionResult> ProductInfo(Guid id)
	{
		var product = await _product.GetProduct(id);
		var similarProduct = await _product.GetProductsGroup(id);
		AllViewModel viewModel = new AllViewModel()
		{
			productInfo = product,
		};
		ViewBag.SimilarProduct = similarProduct;
		return View(viewModel);
	}

}
