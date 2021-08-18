using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
