using Dto.Payment;
using Dto.Response.Payment;
using RubikBook.Core.Interface;
using RubikBook.Database.Context;
using ZarinPal.Class;

namespace RubikBook.Core.Services;

public class PayService : IPay
{
    private readonly DatabaseContext _context;

    //zarinpal
    private readonly Payment _payment;
    private readonly Authority _authority;
    private readonly Transactions _transactions;

    private const string merchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"; //zarinpal test

    IProfile _profile;

    public PayService(DatabaseContext context, IProfile profile)
    {
        _context = context;
        _profile = profile;

        //zarinpal
        var expose = new Expose();
        _transactions = new Transactions();
        _authority = new Authority();
        _payment = new Payment();


    }


    public void Dispose()
    {
        if (_context!=null)
        {
            _context.Dispose();
        }
    }

    public async Task<Request> ShoppingPayment(Guid factorId)
    {
        var factor = await _profile.GetFactor(factorId);
        if (factor == null)
        {
            return null;
        }
        if (!factor.IsPay)
        {
            var result = await _payment.Request(new DtoRequest()
            {
                Amount = factor.FactorDetails.Sum(d => d.DetailPrice),
                MerchantId = merchantId,
                CallbackUrl = "https://localhost:7182",
                Email = "",
                Mobile = "",
                Description = "فروشگاه کتاب روبیک بوک"
            }, Payment.Mode.sandbox //zarinpal test
            );
            return result;
        }
        return null;
    }
}
