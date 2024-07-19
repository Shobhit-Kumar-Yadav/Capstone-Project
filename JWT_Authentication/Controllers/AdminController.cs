using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace JWT_Authentication.Controllers
{
	[Authorize(Roles="Admin")]
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		[HttpGet]
		public IActionResult Get()
		{
			return Ok("You have accessed the Admin controller.");
		}
	}
}
