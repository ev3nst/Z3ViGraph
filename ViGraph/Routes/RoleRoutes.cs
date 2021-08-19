namespace ViGraph
{
	public static partial class Routes
	{
		public const string ListRoles = nameof(ListRoles);
		public const string ListRolesPath = "/roles";

		public const string ListRolesApi = nameof(ListRolesApi);
		public const string ListRolesApiPath = "/roles/api";

		public const string ListRolesTrashApi = nameof(ListRolesTrashApi);
		public const string ListRolesTrashApiPath = "/roles/trash/api";

		public const string EditRole = nameof(EditRole);
		public const string EditRolePath = "/roles/{Id}";

		public const string DeleteRole = nameof(DeleteRole);
		public const string DeleteRolePath = "/roles/{Id}";

		public const string RestoreRole = nameof(RestoreRole);
		public const string RestoreRolePath = "/roles/restore/{Id}";

		public const string PermaDeleteRole = nameof(PermaDeleteRole);
		public const string PermaDeleteRolePath = "/roles/permanently-delete/{Id}";
	}
}
