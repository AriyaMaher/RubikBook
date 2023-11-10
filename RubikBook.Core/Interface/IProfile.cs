using RubikBook.Core.Services;
using RubikBook.Core.ViewModels;
using RubikBook.Database.Models;

namespace RubikBook.Core.Interface;

public interface IProfile : IDisposable
{
    Task<User> GetUser(string userMobile);
    Task<Guid> AddShopping(ShoppingViewModel shopping); //return factorId
    Task<Factor> GetFactor(Guid userId, bool? isPay = false);
    Task<Factor> GetFactor(Guid factorId);
}
