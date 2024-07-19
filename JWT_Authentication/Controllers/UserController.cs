using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace JWT_Authentication.Controllers
{
	[Authorize(Roles = "User")]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("You have accessed the User controller.");
		}
	}
}
