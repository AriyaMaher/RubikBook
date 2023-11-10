using Microsoft.EntityFrameworkCore;
using RubikBook.Core.Interface;
using RubikBook.Database.Context;

namespace RubikBook.Core.Services;

public class PayService : IPay
{

    IProfile _profile;
    private readonly DbContext _context;

    public PayService(DatabaseContext context,IProfile profile)
    {
        _context = context;
        _profile = profile;
    }


    public void Dispose()
    {
        if (_context!=null)
        {
            _context.Dispose();
        }
    }

    //public async Task<bool> ShoppingPayment(Guid factorId)
    //{
    //    var order = await _profile.GetFactor(factorId, false);
    //    var userMobile = order.User.Mobile.ToString();
    //    if (order==null)
    //    {
    //        return false;
    //    }
    //    var payment = new Payment(order.TotalPrice);
    //    var res = payment.PaymentRequest($"پرداخت فاکتور شماره {order.Id}", "https://localhost:44360/profile/ShoppingCart"+order.Id,"UserEmail@gmail.com"+userMobile);

    //    if (res.Result.Status == 100)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
}
