using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Database.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Display(Name ="نام محصول")]
    [Required(ErrorMessage = "درج نام محصول الزامی است")]
    [MaxLength(25)]
    public string ProductName { get; set; }

    [Display(Name ="گروه")]
    [Required(ErrorMessage ="انتخاب گروه الزامی است")]
    public int GroupId { get; set; }

    [Display(Name ="نویسنده")]
    [Required(ErrorMessage ="انتخاب نویسنده الزامی است")]
    public int AuthorId { get; set; }

    [Display(Name ="ناشر")]
    [Required(ErrorMessage ="انتخاب ناشر الزامی است")]
    public int PublisherId { get; set; }

    [Display(Name ="تعداد صفحات")]
    public string? TotalPages { get; set; }

    [Display(Name = "نوع جلد")]
    public string? CoverType { get; set; }

    [Display(Name="درباره محصول")]
    [MaxLength(125)]
    public string? Des { get; set; }

    [Display(Name = "تصویر محصول")]
    [Required(ErrorMessage = "بارگذاری تصویر الزامی است")]
    public string Img { get; set; }

    [Display(Name= "قیمت محصول")]
    [Required(ErrorMessage = "درج قیمت محصول الزامی است")]
    public int Price { get; set; }

    [Display(Name = "موجودی", Prompt = "موجودی")]
    [Required(ErrorMessage = "درج تعداد موجودی الزامی است")]
    public int Inventory { get; set; }

    [Display(Name = "درصد تخفیف", Prompt = "درصد تخفیف")]
    public int SellOff { get; set; }

    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;



    [ForeignKey("GroupId")]
    public virtual Group? Group { get; set; }

    [ForeignKey("AuthorId")]
    public virtual Author? Author { get; set; }

    [ForeignKey("PublisherId")]
    public virtual Publisher? Publisher { get; set; }

}
