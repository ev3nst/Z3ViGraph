using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
	public class YTPlaylistItem
	{
		[Required]
		public int YTPlaylistId { get; set; }

		[ForeignKey("YTPlaylistId")]
		public virtual YTPlaylist YTPlaylist { get; set; }

		[Required]
		public int VideoId { get; set; }

		[ForeignKey("VideoId")]
		public virtual Video Video { get; set; }

		[Required]
		public int Position { get; set; } = 0;

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public DateTime? UpdatedAt { get; set; } = null;

		[Required]
		public int CreatedById { get; set; }

		[ForeignKey("CreatedById")]
		public virtual AppUser CreatedBy { get; set; }

		public int? UpdatedById { get; set; }

		[ForeignKey("UpdatedById")]
		public virtual AppUser UpdatedBy { get; set; }
	}
}
