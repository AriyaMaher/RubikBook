using RubikBook.Core.Interface;
using RubikBook.Database.Context;
using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Core.Services;

public class AgeCategoryService : IAgeCategory
{
    private readonly DatabaseContext _context;
	public AgeCategoryService(DatabaseContext context)
	{
		_context = context;
	}

    public async Task<bool> AddAgeCate(AgeCategory ageCategory)
    {
		try
		{
			_context.AgeCategorys.Add(ageCategory);
			await _context.SaveChangesAsync();
			return await Task.FromResult(true);
		}
		catch (Exception)
		{

			return await Task.FromResult(false);
		}
    }

	public async Task<bool> DeleteAge(int ageCateId)
	{
		var age = await _context.AgeCategorys.FindAsync(ageCateId);
		if (age != null)
		{
			_context.AgeCategorys.Remove(age);
			await _context.SaveChangesAsync();
			return await Task.FromResult(true);
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

	public async Task<List<AgeCategory>> GetAgeCategories()
	{
		var ageCategories = _context.AgeCategorys.ToList();
		return await Task.FromResult(ageCategories);
	}

	public async Task<AgeCategory> GetAgeCategory(int id)
	{
		var age = await _context.AgeCategorys.FindAsync(id);
		return await Task.FromResult(age);
	}
}
