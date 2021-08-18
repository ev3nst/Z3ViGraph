using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class VideoViewCountSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VideoViewCount>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<VideoViewCount>(videoViewCount => {
				videoViewCount.ToTable("VideoViewCounts");
				videoViewCount.HasKey(c => new { c.VideoId });
			});
		}

		public static List<VideoViewCount> GetData()
		{
			var viewCountList = new List<VideoViewCount>();
			return viewCountList;
		}
	}
}