using System;

namespace ViGraph.Models.DTO
{
	public class AppRoleDTO
	{
		public int Id { get; set; }

		public string Sef { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? DeletedAt { get; set; } = null;

		public string ActionsHTML { get; set; }
	}
}
