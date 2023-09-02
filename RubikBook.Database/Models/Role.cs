
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RubikBook.Database.Models;

public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "کد نقش")]
    public Guid Id { get; set; }

    [Required]
    [Display(Name = "نام نقش")]
    public string RoleName { get; set; }//en


    [Required]
    [Display(Name = "عنوان نقش")]
    public string RoleTitle { get; set; }//fa


    public virtual ICollection<User> Users { get; set; }
}
