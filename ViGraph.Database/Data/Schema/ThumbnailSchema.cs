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
				thumbnail.Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
				thumbnail.HasKey(c => new { c.VideoId, c.Size });

				thumbnail.HasOne<Video>(x => x.Video)
					.WithMany(ur => ur.Thumbnails)
					.HasForeignKey(x => x.VideoId)
					.IsRequired();
			});
		}

		public static List<Thumbnail> GetData()
		{
			var thumbnailList = new List<Thumbnail>();
			return thumbnailList;
		}
	}
}