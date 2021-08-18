using System;

namespace ViGraph.Models.DTO
{
	public class ThumbnailDTO
	{
		public string FilePath { get; set; }

		public string VideoTitle { get; set; }

		public string Size { get; set; }

		public string CreatedByName { get; set; }

		public DateTime CreatedAt { get; set; }

		public string ActionsHTML { get; set; }
	}
}
