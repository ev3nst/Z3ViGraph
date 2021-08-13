using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class YTPlaylistItemSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTPlaylistItem>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTPlaylistItem>().ToTable("YTPlaylistItems");
			modelBuilder.Entity<YTPlaylistItem>().Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
			modelBuilder.Entity<YTPlaylistItem>().Property(c => c.UpdatedAt).HasColumnName("UpdatedAt").HasPrecision(0);
			modelBuilder.Entity<YTPlaylistItem>().HasNoKey();
			modelBuilder.Entity<YTPlaylistItem>()
			.HasIndex(c => new { c.YTPlaylistId, c.Position }).IsUnique();
		}

		public static List<YTPlaylistItem> GetData()
		{
			var ytPlaylistItemList = new List<YTPlaylistItem>();
			return ytPlaylistItemList;
		}
	}
}