using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RubikBook.Classes;

namespace RubikBook.Areas.Admin.Controllers;

[Area("admin")]
[Authorize]
[RoleAttribute("admin")]
public class PanelController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
