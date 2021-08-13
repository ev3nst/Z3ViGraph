using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
	public enum YTUploadStatus
	{
		Initialized,
		Started,
		Deleted,
		Failed,
		Processed,
		Rejected,
		Uploaded
	};

	public class Video
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int HDFileId { get; set; }

		[ForeignKey("HDFileId")]
		public virtual AppFile HDFile { get; set; }

		[Required]
		public int SDFileId { get; set; }

		[ForeignKey("SDFileId")]
		public virtual AppFile SDFile { get; set; }

		[Required]
		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		public virtual Category Category { get; set; }

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
		public int YTMetaId { get; set; }

		[ForeignKey("YTMetaId")]
		public virtual YTMeta YTMeta { get; set; }

		[Required]
		public int YTCategoryId { get; set; }

		[ForeignKey("YTCategoryId")]
		public virtual YTCategory YTCategory { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public DateTime? UpdatedAt { get; set; } = null;

		public DateTime? DeletedAt { get; set; } = null;

		[Required]
		public int CreatedById { get; set; }

		[ForeignKey("CreatedById")]
		public virtual AppUser CreatedBy { get; set; }

		public int? UpdatedById { get; set; }

		[ForeignKey("UpdatedById")]
		public virtual AppUser UpdatedBy { get; set; }

		[Required]
		[Column(TypeName = "enum('initialized', 'started', 'deleted','failed', 'processed', 'rejected', 'uploaded')")]
		public YTUploadStatus UploadStatus { get; set; } = YTUploadStatus.Initialized;
	}
}
