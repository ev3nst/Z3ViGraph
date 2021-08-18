using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Schema
{
	public static class CategorySchema
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(GetData());
		}

		public static void Structure(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>(category => {
				category.ToTable("Categories");
				category.Property(c => c.CreatedAt).HasColumnName("CreatedAt").HasPrecision(0);
				category.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt").HasPrecision(0);
				category.Property(c => c.DeletedAt).HasColumnName("DeletedAt").HasPrecision(0);
				category.HasIndex(c => new { c.Sef }).IsUnique();
			});
		}

		public static List<Category> GetData()
		{
			var categoryList = new List<Category>();

			if (System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development") {
				categoryList.Add(new Category
				{
					Id = 1,
					Title = "Gündem",
					Sef = "gundem",
					CreatedById = 1
				});

				categoryList.Add(new Category
				{
					Id = 2,
					Title = "Spor",
					Sef = "spor",
					CreatedById = 1
				});

				categoryList.Add(new Category
				{
					Id = 3,
					Title = "Yaşam",
					Sef = "yasam",
					CreatedById = 1
				});
			}

			return categoryList;
		}
	}
}
