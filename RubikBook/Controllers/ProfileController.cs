using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;
using RubikBook.Core.ViewModels;
using RubikBook.Database.Models;

namespace RubikBook.Controllers;

[Authorize]
public class ProfileController : Controller
{
	IProfile _profile;
    public ProfileController(IProfile profile)
    {
        _profile = profile;
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
    public async Task<Guid> AddtoShoppingcart(ShoppingViewModel shopping)
    {
        var factorId = await _profile.AddShopping(shopping);
        return factorId;

    }

    public async Task<IActionResult> ShoppingCart()
    {
        var user = await _profile.GetUser(User.Identity.Name);

        var factor = await _profile.GetFactor(user.Id, false);
        return View(factor);
    }


}
