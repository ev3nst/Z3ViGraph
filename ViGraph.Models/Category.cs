using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Title { get; set; }

		[Required]
		[MaxLength(255)]
		public string Sef { get; set; }

		public string Description { get; set; }

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
