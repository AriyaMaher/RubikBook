using RubikBook.Database.Models;

namespace RubikBook.Core.ViewModels;

public class AllViewModel
{
    public IEnumerable<Group>? Groups { get; set; } = null;
    public IEnumerable<Author>? Authors { get; set; } = null;
    public IEnumerable<Group>? GroupsForHeader { get; set; } = null;
    public IEnumerable<Author>? AuthorsForHeader { get; set; } = null;
    public IEnumerable<Product>? Products { get; set; } = null;
    public IEnumerable<Product>? ProductsSellOff { get; set; } = null;
    public IEnumerable<Product>? ProductsSearch { get; set; } = null;

    public Product productInfo { get; set; }
    public ShoppingViewModel shopping { get; set; }
    public IEnumerable<Product>? SimilarProduct { get; set; } = null;
}
