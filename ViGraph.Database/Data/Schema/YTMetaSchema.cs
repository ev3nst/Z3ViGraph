using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class YTMetaSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTMeta>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<YTMeta>(ytMeta => {
				ytMeta.ToTable("YTMetas");
				ytMeta.Property(c => c.PublishedAt).HasColumnName("PublishedAt").HasPrecision(0);
				ytMeta.HasIndex(c => new { c.YTId }).IsUnique();
			});
		}

		public static List<YTMeta> GetData()
		{
			var ytMetaList = new List<YTMeta>();
			return ytMetaList;
		}
	}
}