using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;
using RubikBook.Core.ViewModels;
using RubikBook.Database.Context;
using RubikBook.Database.Models;
using ZarinPal.Class;
using Dto.Payment;
using Dto.Response.Payment;

namespace RubikBook.Controllers;

[Authorize]
public class ProfileController : Controller
{



    IProfile _profile;
    IProduct _product;
    private readonly DatabaseContext _context;
    public ProfileController(IProfile profile, IProduct product, DatabaseContext context)
    {
        _profile = profile;
        _product = product;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _profile.GetUser(userMobile: User.Identity.Name);
        if (user.Role.RoleName == "admin")
        {
            return Redirect("~/admin/panel");
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddtoShoppingcart(ShoppingViewModel shopping)
    {
        var factorId = await _profile.AddShopping(shopping);
        if (factorId != null)
        {
            ViewBag.MessageTrue = "به سبد خرید اضافه شد";
            return RedirectToAction("Index", "Home");
        }
        ViewBag.MessageFalse = "به سبد خرید اضافه نشد لطفا دوباره امتحان کن";
        return RedirectToAction("Index", "Home");
    }


    public async Task<IActionResult> AddtoShoppingcartPlus(Guid id) // +
    {
        var product = await _product.GetProduct(id);

        var user = await _profile.GetUser(User.Identity.Name);
        ShoppingViewModel shoppingViewModel = new ShoppingViewModel()
        {
            UserId = user.Id,
            ProductId = product.Id,
        };
        var factorId = await _profile.AddShopping(shoppingViewModel);
        return RedirectToAction("ShoppingCart");
    }


    //public async Task<IActionResult> MinusShoppingcart(Guid id) // -
    //{

    //}



    public async Task<IActionResult> ShoppingCart()
    {
        var user = await _profile.GetUser(User.Identity.Name);
        var userAddress = await _profile.GetUserAddress(user.Id);
        ViewBag.UserAddress = userAddress;
        var factor = await _profile.GetFactor(user.Id, false);
        if (factor != null)
        {
            ViewBag.True = true;
            return View(factor);
        }
        ViewBag.False = false;
        return View();
    }

    public async Task<IActionResult> UserAdddress()
    {
        var user = await _profile.GetUser(User.Identity.Name);
        var userAddress = await _profile.GetUserAddress(user.Id);
        if (userAddress!=null)
        {
            return View(userAddress);
        }
        return View();
    }

    public async Task<IActionResult> AddUserAdddress()
    {
        var user = await _profile.GetUser(User.Identity.Name);
        var userAddress = await _profile.GetUserAddress(user.Id);

        ViewBag.UserId = user.Id;
        ViewBag.userAddress = userAddress;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddUserAdddress(UserAddressViewModel userAddressViewModel)
    {
        var user = await _profile.GetUser(User.Identity.Name);
        var userAddress = await _profile.GetUserAddress(user.Id);
        if (ModelState.IsValid)
        {
            var userA = await _profile.AddUserAddress(userAddressViewModel);
            return RedirectToAction("ShoppingCart");
        }
        ViewBag.UserId = user.Id;
        ViewBag.userAddress = userAddress;
        return View();
    }


    public async Task<IActionResult> DeleteUserAdddress(/*Guid userId*/)
    {
        var user = await _profile.GetUser(User.Identity.Name);
        var userAddress = await _profile.DeleteUserAddress(user.Id);
        if (userAddress)
        {
            return RedirectToAction("UserAdddress");
        }
        return View();

    }


    public async Task<IActionResult> DeleteOrder(Guid id) //Delete factorDetail
    {
        var product = await _product.GetProduct(id);
        if (product != null)
        {
            var user = await _profile.GetUser(User.Identity.Name);
            var factor = await _profile.GetFactor(user.Id, false);

            var result = await _profile.DeleteFactorDetail(factor.Id, product.Id, user.Id);

            return RedirectToAction(nameof(ShoppingCart));
        }
        return View();
    }



    public async Task<IActionResult> MinusFactorDetail(Guid id)
    {
        var product = await _product.GetProduct(id);
        if (product != null)
        {
            var user = await _profile.GetUser(User.Identity.Name);
            var factor = await _profile.GetFactor(user.Id, false);

            var result = await _profile.MinusFactorDetail(factor.Id,product.Id,user.Id);
            return RedirectToAction("DeleteFactor");
        }
        return View();

    }


    //public async Task<IActionResult> OnlinePayment(Guid id)
    //{
    //    if (HttpContext.Request.Query["Status"] != "" &&
    //        HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
    //        HttpContext.Request.Query["Authority"] != "")
    //    {
    //        var order = await _profile.GetFactor(id);

    //        string authority = HttpContext.Request.Query["Authority"].ToString();
    //        var payment = new Payment(order.TotalPrice);
    //        var res = payment.Verification(authority).Result;

    //        if (res.Status == 100)
    //        {

    //            ViewBag.code = res;

    //            order.IsPay = true;
    //            _context.Factors.Update(order); //order == factor
    //            _context.SaveChanges();

    //            return View();
    //        }
    //    }
    //    return BadRequest();

    //}
}

