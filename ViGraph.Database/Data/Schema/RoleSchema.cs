using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class RoleSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppRole>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppRole>(role => {
				role.ToTable("Roles");
				role.HasKey(r => r.Id);
				role.HasIndex(r => r.NormalizedName).IsUnique();
				role.HasIndex(r => r.Sef).IsUnique();
				role.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

				role.Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
				role.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt").HasPrecision(0);
				role.Property(c => c.DeletedAt).HasColumnName("DeletedAt").HasPrecision(0);

				role.HasMany<AppUserRole>()
					.WithOne(ur => ur.Role)
					.HasForeignKey(ur => ur.RoleId)
					.IsRequired();

				role.HasMany<AppRoleClaim>(u => u.RoleClaims)
					.WithOne(ur => ur.Role)
					.HasForeignKey(ur => ur.RoleId)
					.IsRequired();
			});
		}

		public static List<AppRole> GetData()
		{
			var rolesList = new List<AppRole>();

			rolesList.Add(new AppRole
			{
				Id = 1,
				Name = "Super Admin",
				NormalizedName = "SuperAdmin",
				Sef = "super-admin"
			});

			rolesList.Add(new AppRole
			{
				Id = 2,
				Name = "Admin",
				NormalizedName = "Admin",
				Sef = "admin"
			});

			rolesList.Add(new AppRole
			{
				Id = 3,
				Name = "Editor",
				NormalizedName = "Editor",
				Sef = "editor"
			});

			return rolesList;
		}
	}
}