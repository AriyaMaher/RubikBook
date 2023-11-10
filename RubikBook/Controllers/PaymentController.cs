using Microsoft.AspNetCore.Mvc;
using RubikBook.Core.Interface;

namespace RubikBook.Controllers;

public class PaymentController : Controller
{
    IPay _pay;
    public PaymentController(IPay pay)
    {
        _pay = pay;
    }

    public async Task<IActionResult> ShoppingPay(Guid factorId)
    {
        var result = await _pay.ShoppingPayment(factorId);
        if (result.Status == 100)
        {
            return Redirect("http://sandbox.zarinpal.com/pg/StartPay/" + result.Authority);
        }
        return View();
    }
}
