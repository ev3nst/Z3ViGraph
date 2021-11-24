using System.Collections.Generic;

namespace ViGraph.Utility
{
	public static class Permissions
	{
		public static List<string> PermissionModules()
		{
			return new List<string>() {
				"Dashboard",
				"Report",
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
			if (module == "Dashboard" || module == "Report") {
				return new List<string>() {
					$"{module}.View",
				};
			}

			return new List<string>() {
				$"{module}.Create",
				$"{module}.View",
				$"{module}.Edit",
				$"{module}.Delete",
				$"{module}.Restore",
				$"{module}.ForceDelete",
			};
		}
	}
}
