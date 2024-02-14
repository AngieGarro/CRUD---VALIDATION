using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
	public class User : BaseDTO
	{
		[Required(ErrorMessage = "Name is required.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "LastName 1 is required.")]
		public string LastName1 { get; set; }		

		public string LastName2 { get; set;}

		[Required(ErrorMessage = "Email is required.")]
		[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "The Email attribute to format")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		public string Password { get; set; }

		//SE GENERA EN LA BD
		public string? UserCode { get; set; }

		[Required(ErrorMessage = "Question Secret is required.")]
		public int QuestionSecret { get; set; }

		[Required(ErrorMessage = "Question Secret is required.")]
		public string QuestionAnswer { get; set; }

	}
}
