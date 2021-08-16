using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Utility;

namespace ViGraph.Database.Schema
{
	public static class RoleClaimSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IdentityRoleClaim<int>>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
		}
		public static List<IdentityRoleClaim<int>> GetData()
		{
			var roleClaimList = new List<IdentityRoleClaim<int>>();

            var idCounter = 0;
			foreach (var module in Permissions.PermissionModules()) {
				var allPermissions = Permissions.GeneratePermissionsForModule(module);
				foreach (var permissionClaim in allPermissions) {
                    idCounter++;
					roleClaimList.Add(new IdentityRoleClaim<int>
					{ // Super Admin
                        Id = idCounter,
						ClaimType = "Permission",
						ClaimValue = permissionClaim,
						RoleId = 1
					});

					if (module != "AppUser" && module != "AppRole") {
                        idCounter++;
						roleClaimList.Add(new IdentityRoleClaim<int>
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
						roleClaimList.Add(new IdentityRoleClaim<int>
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