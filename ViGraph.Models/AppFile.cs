using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViGraph.Models
{
    public enum AppFileStatus {
        Initialized,
        Paused,
        Completed,
        Failed
    }

	public class AppFile
	{
        [Key]
        public int Id { get; set; }

		[Required]
        [MaxLength(255)]
        public string Name { get; set; }

		[Required]
        [MaxLength(255)]
        public string OriginalName { get; set; }

		[Required]
        [MaxLength(255)]
        public string Folder { get; set; }

		[Required]
        [MaxLength(50)]
        public string Mime { get; set; }

		[Required]
        [Range(1, 137_438_883_103)]
        public int TotalSize { get; set; }

		[Required]
        [Range(0, 137_438_883_103)]
        public int UploadedSize { get; set; } = 0;

		[Required]
		[Column(TypeName = "enum('Initialized','Paused', 'Completed', 'Failed')")]
        public AppFileStatus Status { get; set; } = AppFileStatus.Initialized;

		[Required]
		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public DateTime? UpdatedAt { get; set; } = null;

		public DateTime? DeletedAt { get; set; } = null;
	}
}


