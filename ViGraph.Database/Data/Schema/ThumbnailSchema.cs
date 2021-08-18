using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class ThumbnailSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Thumbnail>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Thumbnail>(thumbnail => {
				thumbnail.ToTable("Thumbnails");
				thumbnail.HasNoKey();
				thumbnail.Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
				thumbnail.HasIndex(c => new { c.VideoId, c.Size }).IsUnique();
			});
		}

		public static List<Thumbnail> GetData()
		{
			var thumbnailList = new List<Thumbnail>();
			return thumbnailList;
		}
	}
}