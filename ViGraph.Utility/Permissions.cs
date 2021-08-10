using System.Collections.Generic;

namespace ViGraph.Utility
{
	public static class Permissions
	{
		public static List<string> GeneratePermissionsForModule(string module)
		{
			return new List<string>() {
				$"Permissions.{module}.Create",
				$"Permissions.{module}.View",
				$"Permissions.{module}.Edit",
				$"Permissions.{module}.Delete",
				$"Permissions.{module}.Restore",
				$"Permissions.{module}.ForceDelete",
			};
		}

		public static class AppUser
		{
			public const string View = "Permissions.AppUser.View";
			public const string Create = "Permissions.AppUser.Create";
			public const string Edit = "Permissions.AppUser.Edit";
			public const string Delete = "Permissions.AppUser.Delete";
		}

		public static class AppRole
		{
			public const string View = "Permissions.AppRole.View";
			public const string Create = "Permissions.AppRole.Create";
			public const string Edit = "Permissions.AppRole.Edit";
			public const string Delete = "Permissions.AppRole.Delete";
		}
	}
}
