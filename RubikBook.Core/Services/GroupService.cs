using RubikBook.Core.Interface;
using RubikBook.Database.Context;
using RubikBook.Database.Models;

namespace RubikBook.Core.Services;

public class GroupService : IGroup
{
    private readonly DatabaseContext _context;
    public GroupService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> AddGroup(Group group)
    {
        try
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message, Console.BackgroundColor = ConsoleColor.Red, Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
        }
    }

    public async Task<bool> DeleteGroup(int groupId)
    {
        try
        {
            var group = _context.Groups.Find(groupId);
            Console.WriteLine("---->Find GroupId");
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message, Console.BackgroundColor = ConsoleColor.Red, Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
        }
    }

    public async void Dispose()
    {
        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    public async Task<bool> EditGroup(Group group)
    {
        try
        {
            _context.Update(group);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message, Console.BackgroundColor = ConsoleColor.Red, Console.ForegroundColor = ConsoleColor.Yellow);
            return await Task.FromResult(false);
        }
    }

    public async Task<Group> GetGroup(int groupId)
    {
        var group = _context.Groups.Find(groupId); //base on primary key values "Find()"
        return await Task.FromResult(group);
    }

    public async Task<List<Group>> GetGroups(bool? notShow = null)
    {
		Console.WriteLine("--------> Get all group");
		var groups = _context.Groups.ToList();
		if (notShow != null)
		{
			return await Task.FromResult(groups.Where(g => g.NotShow == notShow).ToList());
		}
		return await Task.FromResult(groups);
	}
}
