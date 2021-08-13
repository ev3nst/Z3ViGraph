using System.ComponentModel.DataAnnotations;

namespace ViGraph.Models
{
	public class YTBase
	{
		[MaxLength(255)]
		public string Kind { get; set; }

		[MaxLength(255)]
		public string Etag { get; set; }

		[MaxLength(255)]
		public string YTId { get; set; }

		[MaxLength(255)]
		public string YTChannelId { get; set; }
    }
}