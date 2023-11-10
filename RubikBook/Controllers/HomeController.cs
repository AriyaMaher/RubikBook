using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;
using RubikBook.Core.ViewModels;
using RubikBook.Database.Context;
using RubikBook.Database.Models;

namespace RubikBook.Controllers;

public class HomeController : Controller
{

    IGroup _group;
    IProduct _product;
    IProfile _profile;
    IAuthor _author;
    public HomeController(IGroup group, IProduct product, IProfile profile, IAuthor author)
    {
        _group = group;
        _product = product;
        _profile = profile;
        _author = author;
    }

    public async Task<IActionResult> Index()
    {
        var groups = await _group.GetGroups(notShow: false);
        var headerGroups = (await _group.GetGroups(notShow: false)).Take(5);
        var headerAuhtors = (await _author.GetAuthors()).Take(5);
        var products = (await _product.GetProducts(notShow: false)).Take(6);
        var productSF = (await _product.GetProducts(notShow: false, sellOff: 1)).Take(4);


        AllViewModel allViewModel = new AllViewModel()
        {
            Groups = groups,
            Products = products,
            ProductsSellOff = productSF,
            GroupsForHeader = headerGroups,
            AuthorsForHeader = headerAuhtors,
        };
        return View(allViewModel);
    }

    public async Task<IActionResult> AddShoppingFromIndexPartial(Guid id)
    {
        var product = await _product.GetProduct(id);
        var user = await _profile.GetUser(User.Identity.Name);
        ShoppingViewModel shoppingViewModel = new ShoppingViewModel()
        {
            UserId = user.Id,
            ProductId = product.Id,
        };

        return PartialView(shoppingViewModel);
    }


    public async Task<IActionResult> ProductInfo(Guid id)
    {
        var product = await _product.GetProduct(id);
        var headerGroups = (await _group.GetGroups(notShow: false)).Take(5);
        var headerAuhtors = (await _author.GetAuthors()).Take(5);
        var similarProduct = await _product.GetProductsGroup(id);
        var user = await _profile.GetUser(User.Identity.Name);
        ShoppingViewModel shopping = new ShoppingViewModel();
        if (user == null) goto PRODUCT;

        shopping.UserId = user.Id;
        shopping.ProductId = product.Id;

    PRODUCT:
        AllViewModel viewModel = new AllViewModel()
        {
            productInfo = product,
            shopping = shopping,
            GroupsForHeader = headerGroups,
            AuthorsForHeader = headerAuhtors,
        };
        ViewBag.SimilarProduct = similarProduct;
        return View(viewModel);
    }

    public async Task<IActionResult> AllGroups()
    {
        var groups = await _group.GetGroups(notShow: false);
        var headerGroups = (await _group.GetGroups(notShow: false)).Take(5);
        var headerAuhtors = (await _author.GetAuthors()).Take(5);
        AllViewModel allView = new AllViewModel()
        {
            Groups = groups,
            GroupsForHeader = headerGroups,
            AuthorsForHeader = headerAuhtors,
        };
        return View(allView);
    }

    public async Task<IActionResult> AllAuthors()
    {
        var Authorss = await _author.GetAuthors();
        var headerGroups = (await _group.GetGroups(notShow: false)).Take(5);
        var headerAuhtors = (await _author.GetAuthors()).Take(5);
        AllViewModel allView = new AllViewModel()
        {
            GroupsForHeader = headerGroups,
            AuthorsForHeader = headerAuhtors,
            Authors = Authorss,
        };
        return View(allView);
    }

    public async Task<IActionResult> AllProducts()
    {
        var products = await _product.GetProducts(notShow: false);
        var headerGroups = (await _group.GetGroups(notShow: false)).Take(5);
        var headerAuhtors = (await _author.GetAuthors()).Take(5);
        AllViewModel allView = new AllViewModel()
        {
            Products = products,
            GroupsForHeader = headerGroups,
            AuthorsForHeader = headerAuhtors,
        };
        return View(allView);
    }

    public async Task<IActionResult> AllProductsSellOff()
    {
        var productSF = (await _product.GetProducts(notShow: false, sellOff: 1)).Take(4);
        var headerGroups = (await _group.GetGroups(notShow: false)).Take(5);
        var headerAuhtors = (await _author.GetAuthors()).Take(5);
        AllViewModel allViewModel = new AllViewModel()
        {
            ProductsSellOff = productSF,
            GroupsForHeader = headerGroups,
            AuthorsForHeader = headerAuhtors,
        };
        return View(allViewModel);
    }

    public async Task<IActionResult> productsByGroup(int Id)
    {
        var products = await _product.GetProductsByGroup(Id);
        var headerGroups = (await _group.GetGroups(notShow: false)).Take(5);
        var headerAuhtors = (await _author.GetAuthors()).Take(5);
        AllViewModel allViewModel = new AllViewModel()
        {
            //Products = products,
            GroupsForHeader = headerGroups,
            AuthorsForHeader = headerAuhtors,
        };
        ViewBag.productsByGroup = products;
        return View(allViewModel);
    }

    public async Task<IActionResult> ProductsByAuthor(int id)
    {
        var products = await _product.GetProductsByAuthor(id);
        var headerGroups = (await _group.GetGroups(notShow: false)).Take(5);
        var headerAuhtors = (await _author.GetAuthors()).Take(5);

        AllViewModel allViewModel = new AllViewModel()
        {
            GroupsForHeader = headerGroups,
            AuthorsForHeader = headerAuhtors,
        };
        ViewBag.ProductsByAuthor = products;
        return View(allViewModel);
    }


    public async Task<IActionResult> SearchProduct(string searchString = null)
    {
        var searchProduct = await _product.GetProducts(searchName: searchString);
        var headerGroups = (await _group.GetGroups(notShow: false)).Take(5);
        var headerAuhtors = (await _author.GetAuthors()).Take(5);

        AllViewModel allViewModel = new AllViewModel()
        {
            GroupsForHeader = headerGroups,
            AuthorsForHeader = headerAuhtors,
            ProductsSearch = searchProduct,
        };
        return View(allViewModel);
    }


}
