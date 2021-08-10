using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ViGraph.Models
{

	public class AppRole : IdentityRole
	{
		[Required]
		[MaxLength(255)]
		public string Sef { get; set; }

		[MaxLength(255)]
		public string Description { get; set; } = null;
	}
}
