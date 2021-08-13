using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;

using ViGraph.Models;
using ViGraph.Database.Schema;

namespace ViGraph.Database
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<AppUser> AppUser { get; set; }
		public DbSet<AppRole> AppRole { get; set; }
		public DbSet<YTChannel> YTChannel { get; set; }
		public DbSet<YTCategory> YTCategory { get; set; }
		public DbSet<YTMeta> YTMeta { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Video> Video { get; set; }
		public DbSet<Thumbnail> Thumbnail { get; set; }
		public DbSet<VideoViewCount> VideoViewCount { get; set; }
		public DbSet<YTPlaylist> YTPlaylist { get; set; }
		public DbSet<YTPlaylistItem> YTPlaylistItem { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Migration Modifications
			base.OnModelCreating(modelBuilder);
			UserSchema.Structure(modelBuilder);
			RoleSchema.Structure(modelBuilder);
			UserRoleSchema.Structure(modelBuilder);

			modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
			modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
			modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
			modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

			// Seeds
			RoleSchema.Seed(modelBuilder);
			UserSchema.Seed(modelBuilder);
			UserRoleSchema.Seed(modelBuilder);
		}
	}

    /*
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
    */
}
