using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class YTCategorySchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTCategory>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTCategory>().ToTable("YTCategories");
			modelBuilder.Entity<YTCategory>()
			.HasIndex(c => new { c.YTId }).IsUnique();
		}

		public static List<YTCategory> GetData()
		{
			var ytCategoryList = new List<YTCategory>();
			return ytCategoryList;
		}
	}
}