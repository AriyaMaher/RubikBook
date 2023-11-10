using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;

namespace RubikBook.Areas.Admin.Controllers;

[Area("Admin")]
public class OrdersController : Controller
{
    IProfile _profile;
    IOrders _order;
    public OrdersController(IProfile profile, IOrders order)
    {
        _profile = profile;
        _order = order;
    }


    public async Task<IActionResult> Index()
    {
        var orders = await _order.GetFactors(true);
        return View(orders);
    }
}
