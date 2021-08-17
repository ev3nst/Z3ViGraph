using Microsoft.AspNetCore.Identity;


namespace ViGraph.Models
{
	public class AppUserRole : IdentityUserRole<int>
	{
		public virtual AppUser User { get; set; }

		public virtual AppRole Role { get; set; }
	}
}