using CoreLogic.Managers;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Controller
	{
		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(User user)
		{
			var um = new UserManager();
			um.Create(user);
			return Ok(user);
		}

		//RESTABLECER CLAVE:
		[HttpPut]
		[Route("ProcessPWS")]
		public async Task<IActionResult> ProcessPWS(string pwrd, string QuestionAnswer)
		{
			try
			{
				var cm = new UserManager();
				cm.PasswordReset(pwrd, QuestionAnswer);
				return Ok("Password Update");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}
	}
}
