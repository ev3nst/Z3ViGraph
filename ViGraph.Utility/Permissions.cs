using System.Collections.Generic;

namespace ViGraph.Utility
{
	public static class Permissions
	{
		public static List<string> PermissionModules()
		{
			return new List<string>() {
				"AppFile",
				"AppRole",
				"AppUser",
				"Category",
				"Video",
				"VideoViewCount",
				"YTCategory",
				"YTChannel",
				"YTMeta",
				"YTPlaylist",
				"YTPlaylistItem"
			};
		}

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
	}
}
