using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
	public class VideoViewCount
	{
		[Required]
		public int VideoId { get; set; }

		[ForeignKey("VideoId")]
		public virtual Video Video { get; set; }

		[Required]
		[MinLength(int.MinValue)]
		[MaxLength(int.MaxValue)]
		public int ViewCount { get; set; } = 0;
	}
}
