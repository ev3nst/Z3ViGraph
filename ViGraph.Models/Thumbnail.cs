using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
	public enum ThumbnailSize
	{
		Default,
		Medium,
		High,
		Standart,
		MaxRes
	}

	public class Thumbnail
	{
		[Required]
		public int FileId { get; set; }

		[ForeignKey("FileId")]
		public virtual AppFile File { get; set; }

		[Required]
		public int VideoId { get; set; }

		[ForeignKey("VideoId")]
		public virtual Video Video { get; set; }

		[Required]
		[Range(120, 1280)]
		public int Width { get; set; }

		[Required]
		[Range(90, 720)]
		public int Height { get; set; }

		[Required]
		[Column(TypeName = "enum('default','medium', 'high', 'standart', 'maxres')")]
		public ThumbnailSize Size { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		[Required]
		public int CreatedById { get; set; }

		[ForeignKey("CreatedById")]
		public virtual AppUser CreatedBy { get; set; }

		[NotMapped]
		public string Url { get; set; }
	}
}
