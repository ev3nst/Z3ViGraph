using System.ComponentModel.DataAnnotations;

namespace ViGraph.Models
{
	public class YTCategory : YTBase
	{
        [Key]
        public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Title { get; set; }

		[Required]
		public bool Assignable { get; set; }
	}
}
