using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
	public class YTPlaylistItem
	{
		[Required]
		[ForeignKey("YTPlaylistId")]
		public YTPlaylist YTPlaylist { get; set; }

		[Required]
		public string ResourceId { get; set; }

        public int Position { get; set; } = 0;

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public DateTime? UpdatedAt { get; set; } = null;

		[Required]
		[ForeignKey("CreatedBy")]
        public AppUser CreatedBy { get; set; }

		[ForeignKey("UpdatedBy")]
        public AppUser UpdatedBy { get; set; }
	}
}
