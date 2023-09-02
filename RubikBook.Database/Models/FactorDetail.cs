using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RubikBook.Database.Models;

public class FactorDetail
{

    [Key]
    public int Id { get; set; }

    [Required]
    public Guid FactorId { get; set; }

    [Required]
    public Guid ProductId { get; set; }

    [Display(Name = "تعداد سفارش")]
    public int DetailCount { get; set; }

    [Display(Name = "قیمت مجموع سفارش")]
    public int DetailPrice { get; set; }

    [ForeignKey(nameof(FactorId))]
    public virtual Factor Factor { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }

}
