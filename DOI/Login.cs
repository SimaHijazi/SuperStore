using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperStore2.DOI
{
	public class Login
	{
		[Key]
		[Required(ErrorMessage = "Insert Data")]
		[StringLength(100)]
		public string? Username { get; set; }

		[Required(ErrorMessage = "Insert Data")]
		[DataType(DataType.Password)]
		public string? Password { get; set; }

		public string? Uname { get; set; }

		[ForeignKey("Uname")]
		public Signup? Signup { get; set; }
	}
}
