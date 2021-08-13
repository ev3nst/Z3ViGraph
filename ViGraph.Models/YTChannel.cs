using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
	public class YTChannel : YTBase
	{
		[Key]
		public int Id { get; set; }

        [Required]
		[MaxLength(100)]
		public string Country { get; set; }

		[Required]
		[MaxLength(255)]
		public string Title { get; set; }

		[MaxLength(500)]
		public string Keywords { get; set; }

		[MaxLength(1000)]
		public string Description { get; set; }

		public string About { get; set; }

		[NotMapped]
		public override string YTChannelId { get; set; }
	}
}


