using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using ViGraph.Utility;
using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class RoleClaimSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppRoleClaim>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppRoleClaim>(roleClaim => {
				roleClaim.ToTable("RoleClaims");
				roleClaim.HasIndex(c => new { c.RoleId, c.ClaimValue }).IsUnique();
			});
		}

		public static List<AppRoleClaim> GetData()
		{
			var roleClaimList = new List<AppRoleClaim>();

			var idCounter = 0;
			foreach (var module in Permissions.PermissionModules()) {
				var allPermissions = Permissions.GeneratePermissionsForModule(module);
				foreach (var permissionClaim in allPermissions) {
					idCounter++;
					roleClaimList.Add(new AppRoleClaim
					{ // Super Admin
						Id = idCounter,
						ClaimType = "Permission",
						ClaimValue = permissionClaim,
						RoleId = 1
					});

					if (module != "AppUser" && module != "AppRole") {
						idCounter++;
						roleClaimList.Add(new AppRoleClaim
						{ // Admin
							Id = idCounter,
							ClaimType = "Permission",
							ClaimValue = permissionClaim,
							RoleId = 2
						});
					}

					if (
						module != "AppUser" &&
						module != "AppRole" &&
						module != "Categories" &&
						permissionClaim != "Permissions" + module + ".Restore" &&
						permissionClaim != "Permissions" + module + ".ForceDelete"
					) {
						idCounter++;
						roleClaimList.Add(new AppRoleClaim
						{ // Editor
							Id = idCounter,
							ClaimType = "Permission",
							ClaimValue = permissionClaim,
							RoleId = 3
						});
					}
				}
			}

			return roleClaimList;
		}
	}
}
