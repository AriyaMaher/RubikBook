using RubikBook.Database.Models;
using Microsoft.AspNetCore.Http;
namespace RubikBook.Core.Interface;

public interface IProduct : IDisposable
{
	Task<List<Product>> GetProducts(bool? notShow = null, int? sellOff = null);
    Task<List<Product>> GetProductsGroup(Guid productId);
    Task<Product> GetProduct(Guid id);
    Task<bool> AddProduct(Product product, IFormFile productImg);
    Task<bool> EditProduct(Product product, IFormFile productImg);
    Task<bool> DeleteProduct(Product product);
}
