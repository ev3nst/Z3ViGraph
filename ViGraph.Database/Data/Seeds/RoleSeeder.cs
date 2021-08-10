using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ViGraph.Models;

namespace ViGraph.Database.Seeds
{
	public static class RoleSeeder
	{
		public static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AppRole>().HasData(GetData());
		}

		public static List<AppRole> GetData()
		{
			var rolesList = new List<AppRole>();

			rolesList.Add(new AppRole
			{
				Id = "1",
				Name = "Super Admin",
				Sef = "super-admin"
			});

			rolesList.Add(new AppRole
			{
				Id = "2",
				Name = "Admin",
				Sef = "admin"
			});

			rolesList.Add(new AppRole
			{
				Id = "3",
				Name = "Editor",
				Sef = "editor"
			});

			return rolesList;
		}
	}
}