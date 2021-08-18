using System;

namespace ViGraph.Models.DTO
{
	public class CategoryDTO
	{
		public int Id { get; set; }

		public string Sef { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string CreatedByName { get; set; }

		public string UpdatedByName { get; set; } = null;

		public DateTime CreatedAt { get; set; }

		public DateTime? DeletedAt { get; set; } = null;

		public string ActionsHTML { get; set; }
	}
}
