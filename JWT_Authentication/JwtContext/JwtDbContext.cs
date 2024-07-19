using JWT_Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT_Authentication.JwtContext
{
	public class JwtDbContext:IdentityDbContext<IdentityUser>
	{

		public JwtDbContext(DbContextOptions options) : base(options)
		{
		}
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// Seed roles
			builder.Entity<ApplicationRole>().HasData(
				new ApplicationRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
				new ApplicationRole { Id = "2", Name = "User", NormalizedName = "USER" }
			);
		}

	}
}
