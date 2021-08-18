using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class UserRolesSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppUserRole>().HasData(GetData());
		}

        public static void Structure(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<AppUserRole>().ToTable("UserRoles");
        }
		public static List<AppUserRole> GetData()
		{
			var userRoleList = new List<AppUserRole>();
            userRoleList.Add(new AppUserRole { // Root
                UserId = 1,
                RoleId = 1
            });

			if (System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") {
                // Test Admin & Editor    
                userRoleList.Add(new AppUserRole {
                    UserId = 2,
                    RoleId = 2
                });
                userRoleList.Add(new AppUserRole {
                    UserId = 3,
                    RoleId = 3
                });
			}

			return userRoleList;
		}
	}
}