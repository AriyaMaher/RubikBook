using RubikBook.Core.Interface;
using RubikBook.Database.Context;
using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Core.Services;

public class AuthorService : IAuthor
{
    private readonly DatabaseContext _context;
	public AuthorService(DatabaseContext context)
	{
		_context = context;
	}

    public async Task<bool> AddAuthor(Author author)
    {
		try
		{
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
		catch (Exception)
		{

			return await Task.FromResult(false);
		}

    }

    public async Task<bool> DeleteAuthor(int AuthorId)
    {
		try
		{
			var author = await _context.Authors.FindAsync(AuthorId);
			if (author != null)
			{
				_context.Authors.Remove(author);
				await _context.SaveChangesAsync();
				return await Task.FromResult(true);
			}
		}
		catch (Exception)
		{
			return await Task.FromResult(false);
		}
		return await Task.FromResult(false);
	}

    public async void Dispose()
	{
		if (_context != null)
		{
			_context.DisposeAsync();
		}
	}

	public async Task<bool> EditAuthor(Author author)
	{
		try
		{
			_context.Update(author);
			await _context.SaveChangesAsync();
			return await Task.FromResult(true);
		}
		catch (Exception)
		{
			return await Task.FromResult(false);
		}
	}

	public async Task<Author> GetAuthor(int AuthorId)
	{
		var author = _context.Authors.Find(AuthorId);
		return await Task.FromResult(author);
	}

	public async Task<List<Author>> GetAuthors()
	{
		var authors = _context.Authors.ToList();
		return await Task.FromResult(authors);
	}
}
