using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;
using ViGraph.Utility.Config;

namespace ViGraph.Database.Seeds
{
	public static class UserSeeder
	{
		public static PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppUser>().HasData(GetData());
		}

		public static List<AppUser> GetData()
		{
			var userList = new List<AppUser>();
			userList.Add(createUser(
				Id: "1",
				FullName: "Z3 Root",
				Email: AppConfig.RootCredentials.Email,
				Password: AppConfig.RootCredentials.Password
			));

			if (System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") {
				userList.Add(createUser(
					Id: "2",
					FullName: "Test Admin",
					Email: "test@admin.com",
					Password: "admin123"
				));
				userList.Add(createUser(
					Id: "3",
					FullName: "Test Editor",
					Email: "test@editor.com",
					Password: "editor123"
				));
			}

			return userList;
		}

		public static AppUser createUser(string Id, string FullName, string Email, string Password)
		{
			var user = new AppUser
			{
				Id = Id,
				FullName = FullName,
				Email = Email
			};

			user.PasswordHash = passwordHasher.HashPassword(user, Password);
			return user;
		}
	}
}