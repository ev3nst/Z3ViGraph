using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace ViGraph.Models
{
	public class AppRole : IdentityRole<int>
	{
		[Required]
		[MaxLength(255)]
		public override string Name { get; set; }

		[MaxLength(255)]
		public override string NormalizedName { get; set; }

		[Required]
		[MaxLength(255)]
		public string Sef { get; set; }

		[MaxLength(255)]
		public string Description { get; set; } = null;

		public virtual ICollection<AppRoleClaim> RoleClaims { get; set; }
	}
}
