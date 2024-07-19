using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_Authentication.Models
{
	public class User
	{
		//public string Role { get; set; } = string.Empty;
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Email { get; set; } 
		public string Password { get; set; } 
		[NotMapped]
		public string? ConfirmPassword { get; set; }
		public int RoleId { get; set; }
		public Role? Role { get; set; }
	}
}
