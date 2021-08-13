using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ViGraph.Database.Schema
{
	public static class UserRoleSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IdentityUserRole<int>>().HasData(GetData());
		}

        public static void Structure(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
        }
		public static List<IdentityUserRole<int>> GetData()
		{
			var userRoleList = new List<IdentityUserRole<int>>();
            userRoleList.Add(new IdentityUserRole<int> { // Root
                UserId = 1,
                RoleId = 1
            });

			if (System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") {
                // Test Admin & Editor    
                userRoleList.Add(new IdentityUserRole<int> {
                    UserId = 2,
                    RoleId = 2
                });
                userRoleList.Add(new IdentityUserRole<int> {
                    UserId = 3,
                    RoleId = 3
                });
			}

			return userRoleList;
		}
	}
}