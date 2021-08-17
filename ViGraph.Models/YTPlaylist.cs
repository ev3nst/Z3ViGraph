using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
	public class YTPlaylist : YTBase
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Title { get; set; }

		[Required]
		[MaxLength(255)]
		public string Description { get; set; }

		[Required]
		public int YTMetaId { get; set; }

		[ForeignKey("YTMetaId")]
		public YTMeta YTMeta { get; set; }

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

		[NotMapped]
		public virtual string ActionsHTML { get; set; } = null;
	}
}
