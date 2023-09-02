using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RubikBook.Database.Models;

public class Factor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    [Display(Name = "تاریخ ایجاد فاکتور")]
    public string OpenDateTime { get; set; }

    [Display(Name = "تاریخ پرداخت فاکتور")]
    public string? CloseDateTime { get; set; }

    [Display(Name = "وضعیت پرداخت")]
    public bool IsPay { get; set; } = false;

    [Display(Name = "گزارش تراکنش")]
    public string? PayInfo { get; set; }

    [Display(Name = "وضعیت سفارش")]
    public string? Status { get; set; }

    [Display(Name = "توضیحات")]
    public string? Des { get; set; }

    [Display(Name = "مبلغ فاکتور")]
    public int TotalPrice { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }  
}
