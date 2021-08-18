using System;

namespace ViGraph.Models.DTO
{
	public class AppFileDTO
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string OriginalName { get; set; }

		public string Mime { get; set; }

		public int TotalSize { get; set; }

		public int UploadedSize { get; set; }

		public AppFileStatus Status { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime? DeletedAt { get; set; } = null;

		public string ActionsHTML { get; set; }
	}
}
