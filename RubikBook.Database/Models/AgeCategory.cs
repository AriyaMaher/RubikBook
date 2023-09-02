using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikBook.Database.Models;

public class AgeCategory
{
    [Key]
    public int Id { get; set; }

    [Display(Name ="رده سنی")]
    [Required(ErrorMessage ="رده سنی الزامی است")]
    [MaxLength(25)]
    public string AgeCategoryName { get; set; }

    [Display(Name = "عدم نمایش")]
    public bool NotShow { get; set; } = false;

    public virtual ICollection<Product>? products { get; set; }
}
