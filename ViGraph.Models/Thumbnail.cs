using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
    public enum ThumbnailSize {
        Default,
        Medium,
        High,
        Standart,
        MaxRes
    }

	public class Thumbnail
	{
        [Key]
        public int Id { get; set; }

        [Required]
		[ForeignKey("FileId")]
		public AppFile File { get; set; }

        [Required]
		[ForeignKey("VideoId")]
		public Video Video { get; set; }

        [Required]
        [Range(120, 1280)]
        public int Width { get; set; }

        [Required]
        [Range(90, 720)]
        public int Height { get; set; }

		[Required]
		[Column(TypeName = "enum('default','medium', 'high', 'standart', 'maxres')")]
        public ThumbnailSize Size { get; set; }

        [NotMapped]
        public string Url { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		[Required]
		[ForeignKey("CreatedBy")]
        public AppUser CreatedBy { get; set; }
	}
}
