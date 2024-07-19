using Microsoft.AspNetCore.Identity;


namespace JWT_Authentication.JwtContext
{
	public class ApplicationRole : IdentityRole
	{
		public ApplicationRole() : base() { }
		public ApplicationRole(string roleName) : base(roleName) { }
	}

}
