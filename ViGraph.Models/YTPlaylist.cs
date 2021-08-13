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
		[ForeignKey("YTMetaId")]
		public YTMeta YTMeta { get; set; }

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
