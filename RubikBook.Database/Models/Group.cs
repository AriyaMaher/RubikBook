using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Database.Models;

public class Group
{
    [Key]
    public int Id { get; set; }

    [Display(Name ="نام گروه")]
    [Required(ErrorMessage ="نام گروه الزامی است")]
    [MaxLength(25)]
    public string GroupName { get; set; }

    [Display(Name ="درباره گروه")]
    [MaxLength(100)]
    public string? GroupDes { get; set; }

    [Display(Name ="عدم نمایش")]
    public bool NotShow { get; set; }=false;

    public virtual ICollection<Product>? Products { get; set; }

}
