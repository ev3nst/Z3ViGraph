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

	public class YTMeta : YTBase
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public int PrivacyStatus { get; set; }

		[Required]
		public DateTime PublishedAt { get; set; } = DateTime.Now;

		[Required]
		public string DefaultLanguage { get; set; }

		[Required]
		public bool PublicStatsViewable { get; set; } = true;

		[Required]
		[Column(TypeName = "enum('initialized', 'started', 'deleted','failed', 'processed', 'rejected', 'uploaded')")]
		public YTUploadStatus UploadStatus { get; set; } = YTUploadStatus.Initialized;
	}
}


