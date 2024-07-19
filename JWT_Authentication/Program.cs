
using JWT_Authentication.JwtContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace JWT_Authentication
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<JwtDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQlConnection"));
			});

			builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
			}).AddEntityFrameworkStores<JwtDbContext>().AddDefaultTokenProviders();



			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["Jwt:Issuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
				};
			});
			builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
				options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
			});

			

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


            
            builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            var app = builder.Build();
            //using (var scope = app.Services.CreateScope())
            //{
            //	var services = scope.ServiceProvider;
            //	var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            //	 await SeedRolesAsync(roleManager);
            //}

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
            app.UseCors("MyPolicy");

            app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
			//  static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
			//{
			//	string[] roleNames = { "Admin", "User" };
			//	IdentityResult roleResult;

			//	foreach (var roleName in roleNames)
			//	{
			//		// Check if the role already exists, if not, create it
			//		var roleExist = await roleManager.RoleExistsAsync(roleName);
			//		if (!roleExist)
			//		{
			//			roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
			//		}
			//	}
			//}
		}
	}
}
