using System.ComponentModel.DataAnnotations;

namespace SuperStore2.DOI
{
	public class Signup
	{
		
		[Required]
		[StringLength(100)]
		public string? Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[StringLength(100, MinimumLength = 6)]
		public string? Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string? ConfirmPassword { get; set; }

		[Key]
		[Required]
		[EmailAddress]
		public string? Email { get; set; }


	}
}
