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
	public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
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
			RoleClaimSchema.Structure(modelBuilder);
			modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
			modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
			modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");

            YTMetaSchema.Structure(modelBuilder);
            YTChannelSchema.Structure(modelBuilder);
            YTCategorySchema.Structure(modelBuilder);

			CategorySchema.Structure(modelBuilder);
			VideoSchema.Structure(modelBuilder);
			ThumbnailSchema.Structure(modelBuilder);
			VideoViewCountSchema.Structure(modelBuilder);

            YTPlaylistSchema.Structure(modelBuilder);
			YTPlaylistItemSchema.Structure(modelBuilder);

			// Seeds
            RoleClaimSchema.Seed(modelBuilder);
			RoleSchema.Seed(modelBuilder);
			UserSchema.Seed(modelBuilder);
			UserRoleSchema.Seed(modelBuilder);
            
            YTMetaSchema.Seed(modelBuilder);
            YTChannelSchema.Seed(modelBuilder);
            YTCategorySchema.Seed(modelBuilder);

			CategorySchema.Seed(modelBuilder);
			VideoSchema.Seed(modelBuilder);
			ThumbnailSchema.Seed(modelBuilder);
			VideoViewCountSchema.Seed(modelBuilder);

            YTPlaylistSchema.Seed(modelBuilder);
			YTPlaylistItemSchema.Seed(modelBuilder);
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
