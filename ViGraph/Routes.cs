namespace ViGraph
{
	public static class Routes
	{
		public const string ShowLogin = nameof(ShowLogin);
		public const string ShowLoginPath = "login";

		public const string Login = nameof(Login);
		public const string LoginPath = "login";

		public const string EditUser = nameof(EditUser);
		public const string EditUserPath = "/users/{Id}";

		public const string DeleteUser = nameof(DeleteUser);
		public const string DeleteUserPath = "/users/{Id}";
	}
}
