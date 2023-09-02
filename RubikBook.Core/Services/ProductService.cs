using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RubikBook.Core.Interface;
using RubikBook.Database.Context;
using RubikBook.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Core.Services;

public class ProductService : IProduct
{
	string imgPath = "wwwroot/image/product";

	private readonly DatabaseContext _context;
	public ProductService(DatabaseContext context)
	{
		_context = context;
	}

	public async void Dispose()
	{
		if (_context != null)
		{
			await _context.DisposeAsync();
		}
	}

	public async Task<bool> AddProduct(Product product, IFormFile productImg)
	{
		try
		{

			//save(upload) product img
			//1
			int imgCode = new Random().Next(10000, 100000);
			string imgName = imgCode + ".png";

			//if imgPath directory not exixts
			//2
			if (!Directory.Exists(imgPath))
			{
				Directory.CreateDirectory(imgPath);
			}

			//3
			string savePath = Path.Combine(imgPath, imgName);
			using (Stream stream = new FileStream(savePath, FileMode.Create))
			{
				await productImg.CopyToAsync(stream);
			}

			//add product to database
			product.Img = imgName;
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
			return await Task.FromResult(true);
		}
		catch (Exception)
		{
			throw;
		}
	}

	public async Task<bool> EditProduct(Product product, IFormFile productImg)
	{
		try
		{
            var imgCode = product.Img;
			string imgName = imgCode +".png";

			string savePath = Path.Combine(imgPath, imgName);
			using (Stream stream = new FileStream(savePath, FileMode.Create))
			{
				await productImg.CopyToAsync(stream);
			}
			product.Img = imgName;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
        }
		catch (Exception)
		{
			return await Task.FromResult(false);
		}

	}

	public async Task<List<Product>> GetProducts(bool? notShow = null,int? sellOff = null)
	{
		var products = _context.Products.Include(p=>p.Group).ToList();
		if (notShow!=null)
		{
			products = products.Where(p => p.NotShow == notShow).ToList();
		}
		if (sellOff != null)
		{
			products = products.Where(p=>p.SellOff>=sellOff).ToList();
		}
		return await Task.FromResult(products);
	}

	public async Task<Product> GetProduct(Guid productId)
	{
		var product = await _context.Products.Include(g => g.Group).Include(a=>a.Author).Include(p=>p.Publisher).FirstOrDefaultAsync(i => i.Id == productId);
		return await Task.FromResult(product);
	}

	public async Task<bool> DeleteProduct(Product product)
	{
		try
		{
			var product1 = await _context.Products.FindAsync(product.Id);
			if (product1 != null)
			{
				var imgAddress = Path.Combine(imgPath, product1.Img);
				File.Delete(imgAddress);
			    _context.Products.Remove(product1);
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

	public async Task<List<Product>> GetProductsGroup(Guid productId)
	{
		var product = await _context.Products.FindAsync(productId);
		if (product == null)
			return null;

		var products = _context.Products.Include(g => g.Group).Where(x => !x.NotShow && x.Id != productId && x.GroupId == product.GroupId).ToList();
		return await Task.FromResult(products);
	}

}
