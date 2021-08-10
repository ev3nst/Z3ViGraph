using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

using ViGraph.Models;

namespace ViGraph.Database
{
	// Custom type mapping plugin:
	public class EnumTypeMappingSourcePlugin : IRelationalTypeMappingSourcePlugin
	{
		private readonly IMySqlOptions _options;

		public EnumTypeMappingSourcePlugin(IMySqlOptions options) => _options = options;

		/// <summary>
		/// Return a string type mapping with an `enum` store type, if an `enum()` type has been specified explicitly as the column type.
		/// </summary>
		public RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo)
			=> string.Equals(mappingInfo.StoreTypeNameBase, "enum", StringComparison.OrdinalIgnoreCase)
				? new MySqlStringTypeMapping(mappingInfo.StoreTypeName, _options, StoreTypePostfix.None)
				: null;
	}

	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<AppUser> AppUser { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<IdentityUser>().ToTable("Users");
			modelBuilder.Entity<IdentityUser>()
				.Ignore(c => c.UserName)
				.Ignore(c => c.NormalizedUserName)
				.Ignore(c => c.NormalizedEmail)
				.Ignore(c => c.EmailConfirmed)
				.Ignore(c => c.ConcurrencyStamp)
				.Ignore(c => c.PhoneNumber)
				.Ignore(c => c.PhoneNumberConfirmed)
				.Ignore(c => c.LockoutEnabled)
				.Ignore(c => c.LockoutEnd)
				.Ignore(c => c.TwoFactorEnabled)
				.Ignore(c => c.AccessFailedCount);

			modelBuilder.Entity<IdentityRole>().ToTable("Roles");
			modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
			modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
			modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

			modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
			modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
		}
	}
}
