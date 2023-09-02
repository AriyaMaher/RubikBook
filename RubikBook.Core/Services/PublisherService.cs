using RubikBook.Core.Interface;
using RubikBook.Database.Context;
using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Core.Services;

public class PublisherService : IPublisher
{
    private readonly DatabaseContext _context;
	public PublisherService(DatabaseContext context)
	{
		_context = context;
	}

    public async Task<bool> AddPublisher(Publisher publisher)
    {
		try
		{
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
		catch (Exception)
		{
			return await Task.FromResult(false);
		}
    }

    public async Task<bool> DeletePublisher(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher == null)
        {
            return await Task.FromResult(false);
        }
        _context.Publishers.Remove(publisher);
        await _context.SaveChangesAsync();
        return await Task.FromResult(true);
    }

    public async void Dispose()
	{
		if (_context != null)
		{
			_context.DisposeAsync();
		}
	}

    public async Task<Publisher> GetPublisher(int id)
    {
        var publisher = await _context.Publishers.FindAsync(id);
        if (publisher == null)
        {
            return null;
        }
        return await Task.FromResult(publisher);

    }

    public async Task<List<Publisher>> GetPublishers()
	{
        var publishers = _context.Publishers.ToList();
        return await Task.FromResult(publishers);
    }
}
