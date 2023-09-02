using System.ComponentModel.DataAnnotations;

namespace RubikBook.Core.ViewModels;

public class LoginViewModel
{
	[Display(Name = "شماره موبایل", Prompt = "شماره موبایل 11 رقمی")] //prompt = place holder
	[MaxLength(11, ErrorMessage = "شماره موبایل 11 رقمی")]
	[MinLength(11, ErrorMessage = "شماره موبایل 11 رقمی")]
	public string Mobile { get; set; }

	[Display(Name = "رمز عبور", Prompt = "رمز عبور حداقل 8 کاراکتر")]
	[MinLength(8, ErrorMessage = "رمز عبور حداقل 8 کاراکتر")]
	[MaxLength(25, ErrorMessage = "رمز عبور حداقل 25 کاراکتر")]
	[DataType(DataType.Password)] //hide your caracter
	public string Password { get; set; }
}
