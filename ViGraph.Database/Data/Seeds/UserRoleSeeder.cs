using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ViGraph.Database.Seeds
{
	public static class UserRoleSeeder
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IdentityUserRole<string>>().HasData(GetData());
		}

		public static List<IdentityUserRole<string>> GetData()
		{
			var userRoleList = new List<IdentityUserRole<string>>();
            userRoleList.Add(new IdentityUserRole<string> { // Root
                UserId = "1",
                RoleId = "1"
            });

			if (System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") {
                // Test Admin & Editor    
                userRoleList.Add(new IdentityUserRole<string> {
                    UserId = "2",
                    RoleId = "2"
                });
                userRoleList.Add(new IdentityUserRole<string> {
                    UserId = "3",
                    RoleId = "3"
                });
			}

			return userRoleList;
		}
	}
}