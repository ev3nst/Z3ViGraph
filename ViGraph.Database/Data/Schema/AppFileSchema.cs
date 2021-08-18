using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class AppFileSchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppFile>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppFile>(appFile => {
				appFile.ToTable("Files");
				appFile.Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
				appFile.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt").HasPrecision(0);
				appFile.Property(c => c.DeletedAt).HasColumnName("DeletedAt").HasPrecision(0);
				appFile.HasIndex(c => new { c.Name, c.Folder }).IsUnique();
			});
		}

		public static List<AppFile> GetData()
		{
			var appFileList = new List<AppFile>();
			return appFileList;
		}
	}
}
