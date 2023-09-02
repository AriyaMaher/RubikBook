using RubikBook.Core.Services;
using RubikBook.Database.Models;

namespace RubikBook.Core.Interface;

public interface IProfile : IDisposable
{
    Task<User> GetUser(string userMobile);
}
