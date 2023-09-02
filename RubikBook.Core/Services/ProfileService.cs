using Microsoft.EntityFrameworkCore;
using RubikBook.Core.Interface;
using RubikBook.Database.Context;
using RubikBook.Database.Models;

namespace RubikBook.Core.Services;

public class ProfileService : IProfile
{
    private readonly DatabaseContext _context;
    public ProfileService(DatabaseContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        if (_context != null)
        {
            _context.Dispose();
        }
    }

    public async Task<User> GetUser(string userMobile)
    {
        var user = await _context.Users.Where(u => u.Mobile == userMobile).
            Select(s => new User()
            {
                Id = s.Id,
                Mobile = s.Mobile,
                IsActive = s.IsActive,
                Role = new Role()
                {
                    Id = s.Role.Id,
                    RoleName = s.Role.RoleName,
                }
            }).FirstOrDefaultAsync();

        //var user = await _context.Users.FirstOrDefaultAsync(u => u.Mobile==userMobile);
        return user;
    }
}
