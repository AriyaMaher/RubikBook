using RubikBook.Core.Services;
using RubikBook.Core.ViewModels;
using RubikBook.Database.Models;

namespace RubikBook.Core.Interface;

public interface IProfile : IDisposable
{
    Task<User> GetUser(string userMobile);
    Task<Guid> AddShopping(ShoppingViewModel shopping); //return factorId
    //Task<bool> MinusFactorDetail(Guid factorId , Guid ProductId);
    Task<Factor> GetFactor(Guid userId, bool? isPay = false);
    Task<Factor> GetFactor(Guid factorId);
    Task<List<Factor>> GetFactors(bool? isPay);
    //Task<FactorDetail> GetFactorDetail(FactorDetail factorDetail);
    Task<bool> DeleteFactorDetail(Guid factorId , Guid productId , Guid? userId);
    Task<bool> DeleteFactor(Guid factorId);

    Task<bool> AddUserAddress(UserAddressViewModel userAddressViewModel);
    Task<UserAddress> GetUserAddress(Guid userId);
    Task<bool> DeleteUserAddress(Guid userId);
    Task<UserAddress> EditUserAddress(UserAddressViewModel userAddressViewModel);
    Task<bool> MinusFactorDetail(Guid factorId, Guid productId, Guid? userId);
}
