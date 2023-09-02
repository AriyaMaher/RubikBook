using RubikBook.Database.Models;

namespace RubikBook.Core.ViewModels;

public class AllViewModel
{
    public IEnumerable<Group>? Groups { get; set; } = null;
    public IEnumerable<Product>? Products { get; set; } = null;
    public IEnumerable<Product>? ProductsSellOff { get; set; } = null;

    public Product productInfo { get; set; }
    public IEnumerable<Product>? SimilarProduct { get; set; } = null;
}
