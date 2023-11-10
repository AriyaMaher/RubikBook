
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
namespace RubikBook.Database.Models;

public class UserAddress
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    [Display(Name = "نام خود را وارد کنید")]
    public string Fname { get; set; }

    [Required]
    [Display(Name = "نام خانوادگی خود را وارد کنید")]
    public string Lname { get; set; }

    [Required]
    [Display(Name = " شماره تماس گیرنده را وارد کنید")]
    public string Phone { get; set; }

    [Required]
    [Display(Name = "استان خود را وارد کنید")]
    public string State { get; set; }

    [Required]
    [Display(Name = "شهر خود را وارد کنید")]
    public string City { get; set; }

    [Required]
    [Display(Name = "کد پستی خود را وارد کنید")]
    public string PostalCode { get; set; }

    [Required]
    [Display(Name = "آدرس دقیق خود را وارد کنید")]
    public string FullAdress { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }  
}
