using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NuGet.Configuration;
using RubikBook.Core.Interface;
using RubikBook.Database.Context;
using ZarinPal.Class;
using Dto.Payment;
using Dto.Response.Payment;
using RubikBook.Database.Models;

namespace RubikBook.Controllers;

public class PaymentController : Controller
{

    //zarinpal
    private readonly Payment _payment;
    private readonly Authority _authority;
    private readonly Transactions _transactions;

    private const string merchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"; //zarinpal test


    IPay _pay;
    private readonly DatabaseContext _context;
    public PaymentController(IPay pay,DatabaseContext context)
    {
        _pay = pay;
        _context = context;


        //zarinpal
        var expose = new Expose();
        _transactions = new Transactions();
        _authority = new Authority();
        _payment = new Payment();
    }


    public async Task<IActionResult> ShoppingPay(Guid factorId)
    {
        var order = await _context.Factors.SingleOrDefaultAsync(i=>i.Id==factorId && i.IsPay==false);
        if (order == null)
        {
            return NotFound();
        }
        var result = await _payment.Request(new DtoRequest()
        {
            Amount = order.TotalPrice,
            MerchantId = merchantId,
            CallbackUrl = "https://localhost:44360/profile/OnlinePayment",
            Email = "",
            Mobile = "",
            Description = "فروشگاه کتاب روبیک بوک"
        }, Payment.Mode.sandbox //zarinpal test
        );

        if (result.Status == 100)
        {
            return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + result.Authority);
        }
        else
        {
            return BadRequest();
        }
    }

}
