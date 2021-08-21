using System.Collections.Generic;

namespace ViGraph.Models.ViewModels
{
	public class RoleVM
	{
		public AppRole Role { get; set; }

		public IEnumerable<AppRole> Roles { get; set; }
	}
}
