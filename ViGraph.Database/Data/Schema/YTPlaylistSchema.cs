using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class YTPlaylistSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTPlaylist>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTPlaylist>(ytPlaylist => {
				ytPlaylist.ToTable("YTPlaylists");
				ytPlaylist.Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
				ytPlaylist.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt").HasPrecision(0);
				ytPlaylist.HasIndex(c => new { c.YTMetaId }).IsUnique();
				ytPlaylist.HasIndex(c => new { c.YTId }).IsUnique();

				ytPlaylist.HasMany<YTPlaylistItem>(u => u.YTPlaylistItems)
					.WithOne(ur => ur.YTPlaylist)
					.HasForeignKey(ur => ur.YTPlaylistId)
					.IsRequired();

				ytPlaylist.HasOne<YTMeta>(x => x.YTMeta)
					.WithOne(ur => ur.YTPlaylist)
					.HasForeignKey<YTMeta>(x => x.Id)
					.IsRequired();
			});
		}

		public static List<YTPlaylist> GetData()
		{
			var ytPlaylistList = new List<YTPlaylist>();
			return ytPlaylistList;
		}
	}
}