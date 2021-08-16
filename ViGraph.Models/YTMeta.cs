using System;
using System.ComponentModel.DataAnnotations;

namespace ViGraph.Models
{
	public class YTMeta : YTBase
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string PrivacyStatus { get; set; }

		[Required]
		public DateTime PublishedAt { get; set; } = DateTime.Now;

		[Required]
		[MaxLength(10)]
		public string DefaultLanguage { get; set; }

		[Required]
		public bool PublicStatsViewable { get; set; } = true;
	}
}
