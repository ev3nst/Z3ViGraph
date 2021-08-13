using System.ComponentModel.DataAnnotations;

namespace ViGraph.Models
{
	public class YTBase
	{
		[MaxLength(255)]
		public string Etag { get; set; }

		[MaxLength(255)]
		public string YTId { get; set; }

		[MaxLength(255)]
		public virtual string YTChannelId { get; set; }
	}
}