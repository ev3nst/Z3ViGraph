using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;
using ViGraph.Utility.Config;

namespace ViGraph.Database.Schema
{
	public static class UserSchema
	{
		public static PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

		public static DateTime CreatedAtFixed = new DateTime(2021, 01, 01, 0, 0, 0);

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppUser>(appUser => {
				appUser.ToTable("Users");
				appUser
					.Ignore(c => c.NormalizedEmail)
					.Ignore(c => c.EmailConfirmed)
					.Ignore(c => c.ConcurrencyStamp)
					.Ignore(c => c.PhoneNumber)
					.Ignore(c => c.PhoneNumberConfirmed)
					.Ignore(c => c.TwoFactorEnabled)
					.Ignore(c => c.AccessFailedCount);
				appUser.Property(c => c.LastLogin).HasColumnName("LastLogin").HasPrecision(0);
				appUser.Property(c => c.LastLogout).HasColumnName("LastLogout").HasPrecision(0);
				appUser.Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
				appUser.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt").HasPrecision(0);
				appUser.Property(c => c.DeletedAt).HasColumnName("DeletedAt").HasPrecision(0);
				appUser.Property(c => c.LockoutEnd).HasColumnName("LockoutEnd").HasPrecision(0);

				appUser.HasIndex(u => u.Email).IsUnique();
				appUser.HasIndex(u => u.NormalizedEmail).IsUnique();

				appUser.HasOne<AppUserRole>(x => x.UserRole)
					.WithOne(ur => ur.User)
					.HasForeignKey<AppUserRole>(x => x.UserId)
					.IsRequired();
			});

		}

		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppUser>().HasData(GetData());
		}

		public static List<AppUser> GetData()
		{
			var userList = new List<AppUser>();
			userList.Add(createUser(
				Id: 1,
				FullName: "Z3 Root",
				Email: AppConfig.RootCredentials.Email,
				Password: AppConfig.RootCredentials.Password
			));

			if (System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") {
				userList.Add(createUser(
					Id: 2,
					FullName: "Test Admin",
					Email: "test@admin.com",
					Password: "admin123"
				));
				userList.Add(createUser(
					Id: 3,
					FullName: "Test Editor",
					Email: "test@editor.com",
					Password: "editor123"
				));
			}

			return userList;
		}

		public static AppUser createUser(int Id, string FullName, string Email, string Password)
		{
			var user = new AppUser
			{
				Id = Id,
				FullName = FullName,
				Email = Email,
				NormalizedEmail = Email,
				UserName = Email,
				NormalizedUserName = Email,
				CreatedAt = CreatedAtFixed,
				SecurityStamp = Guid.NewGuid().ToString()
			};

			user.PasswordHash = passwordHasher.HashPassword(user, Password);
			return user;
		}
	}
}