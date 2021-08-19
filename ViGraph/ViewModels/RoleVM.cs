using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using ViGraph.Models;

namespace ViGraph.ViewModels
{
	public class RoleVM
	{
		public AppRole Role { get; set; }

		public IEnumerable<AppRole> Roles { get; set; }
	}
}
