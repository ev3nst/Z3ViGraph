using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ViGraph.Models
{
	public class AppRoleClaim : IdentityRoleClaim<int>
	{
		public override int RoleId { get; set; }

		[ForeignKey("RoleId")]
		public virtual AppRole Role { get; set; }
	}
}
