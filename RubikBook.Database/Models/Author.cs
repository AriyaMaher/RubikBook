using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Database.Models;

public class Author
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "نام نویسنده")]
    [Required(ErrorMessage ="نام نویسنده الزامی است")]
    [MaxLength(30)]
    public string AuthorName { get; set; }

    [Display(Name = "درباره نویسنده")]
    [MaxLength(100)]
    public string? AuthorDes { get; set; }

    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;

    public virtual ICollection<Product>? Products { get; set; }
}
