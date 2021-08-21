using System.Collections.Generic;

namespace ViGraph.Models.ViewModels
{
	public class UserVM
	{
		public AppUser AppUser { get; set; }

		public int RoleId { get; set; }

		public string Password { get; set; }

		public string PasswordConfirm { get; set; }

		public IEnumerable<AppRole> Roles { get; set; }
	}
}
