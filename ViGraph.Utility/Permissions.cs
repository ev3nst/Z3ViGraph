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
