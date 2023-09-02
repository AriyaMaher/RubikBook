using RubikBook.Core.ViewModels;
using RubikBook.Database.Models;

namespace RubikBook.Core.Interface;

public interface IAccount:IDisposable
{
    Task<bool> AddUser(RegisterViewModel register);
    Task<User> LoginUser(LoginViewModel login);
}
