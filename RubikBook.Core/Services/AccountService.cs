using Microsoft.EntityFrameworkCore;
using RubikBook.Core.Interface;
using RubikBook.Core.ViewModels;
using RubikBook.Database.Context;
using RubikBook.Database.Models;
using RubikBook.Database.Classes;
namespace RubikBook.Core.Services;

public class AccountService : IAccount
{
    private readonly DatabaseContext _context;
    public AccountService(DatabaseContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        if (_context != null)
            _context.Dispose();
    }

    public async Task<bool> AddUser(RegisterViewModel register)
    {
        try
        {
            ///user mobile exists or not
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Mobile == register.Mobile);
            if (user != null)
            {
                return false;
            }

            //add user
            User newUser = new User()
            {
                Id = Guid.NewGuid(),
                RoleId = _context.Roles.SingleOrDefault(r => r.RoleName == "user").Id,
                Mobile = register.Mobile,
                Password = await new Security().HashPassword(register.Password),
                IsActive = true,
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("add user error : {0}", e.Message);
            return false;
        }
    }

	public async Task<User> LoginUser(LoginViewModel login)
	{
        try
        {
            var hashPassword = await new Security().HashPassword(login.Password);
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(
                                u => u.Mobile == login.Mobile && u.Password == hashPassword);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        catch (Exception)
        {
            return null;
        }
	}
}
