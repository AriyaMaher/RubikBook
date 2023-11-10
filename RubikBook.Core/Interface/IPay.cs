using Dto.Response.Payment;

namespace RubikBook.Core.Interface;

public interface IPay : IDisposable
{
    Task<Request> ShoppingPayment(Guid factorId);
}
