using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

using ViGraph.Models;
using ViGraph.Database.Seeds;

namespace ViGraph.Database
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<AppUser> AppUser { get; set; }
		public DbSet<AppRole> AppRole { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            // Migration Modifications
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
				.Ignore(c => c.TwoFactorEnabled)
				.Ignore(c => c.AccessFailedCount);
            modelBuilder.Entity<AppUser>().Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);

			modelBuilder.Entity<IdentityRole>().ToTable("Roles");
			modelBuilder.Entity<IdentityRole>()
				.Ignore(c => c.NormalizedName);

			modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
			modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
			modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
			modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
			modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            // Seeds
			RoleSeeder.Seed(modelBuilder);
			UserSeeder.Seed(modelBuilder);
			UserRoleSeeder.Seed(modelBuilder);
		}
	}

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
}
