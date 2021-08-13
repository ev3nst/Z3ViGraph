using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class YTChannelSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTChannel>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTChannel>().ToTable("YTChannels");
			modelBuilder.Entity<YTChannel>()
			.HasIndex(c => new { c.YTId }).IsUnique();
		}

		public static List<YTChannel> GetData()
		{
			var ytChannelList = new List<YTChannel>();
			return ytChannelList;
		}
	}
}