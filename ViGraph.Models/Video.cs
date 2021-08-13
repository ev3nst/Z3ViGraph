using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
	public class Video
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[ForeignKey("HDFileId")]
		public AppFile HDFile { get; set; }

		[Required]
		[ForeignKey("SDFileId")]
		public AppFile SDFile { get; set; }

		[Required]
		[ForeignKey("CategoryId")]
		public Category Category { get; set; }

		[Required]
		[MaxLength(255)]
		public string Title { get; set; }

		[MaxLength(500)]
		public string Tags { get; set; }

		[MaxLength(5000)]
		public string Description { get; set; }

		[Required]
		[Range(1, int.MaxValue)]
		public int Duration { get; set; }

		[Required]
		[ForeignKey("YTMetaId")]
		public YTMeta YTMeta { get; set; }

		[Required]
		[ForeignKey("YTCategoryId")]
		public int YTCategory { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public DateTime? UpdatedAt { get; set; } = null;

		public DateTime? DeletedAt { get; set; } = null;

		[Required]
		[ForeignKey("CreatedBy")]
        public AppUser CreatedBy { get; set; }

		[ForeignKey("UpdatedBy")]
        public AppUser UpdatedBy { get; set; }
	}
}
