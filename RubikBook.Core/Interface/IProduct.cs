using RubikBook.Database.Models;
using Microsoft.AspNetCore.Http;
namespace RubikBook.Core.Interface;

public interface IProduct : IDisposable
{
	Task<List<Product>> GetProducts(bool? notShow = null, int? sellOff = null, string? searchName = null);
    Task<List<Product>> GetProductsGroup(Guid productId); //similar products
    Task<List<Product>> GetProductsByGroup(int groupId); //get all products on that group
    Task<List<Product>> GetProductsByAuthor(int authorId);
    Task<Product> GetProduct(Guid id);
    Task<bool> AddProduct(Product product, IFormFile productImg);
    Task<bool> EditProduct(Product product, IFormFile productImg);
    Task<bool> DeleteProduct(Product product);
}
