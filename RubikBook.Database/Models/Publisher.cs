using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Database.Models;

public class Publisher
{
    [Key]
    public int Id { get; set; }

    [Display(Name ="نام ناشر")]
    [Required(ErrorMessage ="نام ناشر الزامی است")]
    [MaxLength(25)]
    public string PublisherName { get; set; }

    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;

    public virtual ICollection<Product>? products { get; set; }
}
