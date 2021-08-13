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
			modelBuilder.Entity<YTPlaylist>().ToTable("YTPlaylists");
			modelBuilder.Entity<YTPlaylist>().Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
			modelBuilder.Entity<YTPlaylist>().Property(c => c.UpdatedAt).HasColumnName("UpdatedAt").HasPrecision(0);
			modelBuilder.Entity<YTPlaylist>()
			.HasIndex(c => new { c.YTMetaId }).IsUnique();
			modelBuilder.Entity<YTPlaylist>()
			.HasIndex(c => new { c.YTId }).IsUnique();
		}

		public static List<YTPlaylist> GetData()
		{
			var ytPlaylistList = new List<YTPlaylist>();
			return ytPlaylistList;
		}
	}
}