using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class VideoSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Video>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Video>(video => {
				video.ToTable("Videos");
				video.Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
				video.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt").HasPrecision(0);
				video.Property(c => c.DeletedAt).HasColumnName("DeletedAt").HasPrecision(0);
				video.HasIndex(c => new { c.YTMetaId }).IsUnique();
			});
		}

		public static List<Video> GetData()
		{
			var videoList = new List<Video>();
			return videoList;
		}
	}
}