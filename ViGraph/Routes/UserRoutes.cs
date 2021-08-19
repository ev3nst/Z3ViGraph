namespace ViGraph
{
	public static partial class Routes
	{
		public const string ShowLogin = nameof(ShowLogin);
		public const string ShowLoginPath = "login";

		public const string Login = nameof(Login);
		public const string LoginPath = "login";

		public const string ListUsers = nameof(ListUsers);
		public const string ListUsersPath = "/users";

		public const string ListUsersApi = nameof(ListUsersApi);
		public const string ListUsersApiPath = "/users/api";

		public const string ListUsersTrashApi = nameof(ListUsersTrashApi);
		public const string ListUsersTrashApiPath = "/users/trash/api";

		public const string EditUser = nameof(EditUser);
		public const string EditUserPath = "/users/{Id}";

		public const string UpdateUser = nameof(UpdateUser);
		public const string UpdateUserPath = "/users/{Id}";

		public const string DeleteUser = nameof(DeleteUser);
		public const string DeleteUserPath = "/users/{Id}";

		public const string RestoreUser = nameof(RestoreUser);
		public const string RestoreUserPath = "/users/restore/{Id}";

		public const string PermaDeleteUser = nameof(PermaDeleteUser);
		public const string PermaDeleteUserPath = "/users/permanently-delete/{Id}";
	}
}
