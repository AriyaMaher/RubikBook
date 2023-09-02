    using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;
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
}
