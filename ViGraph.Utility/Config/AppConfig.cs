namespace ViGraph.Utility.Config
{
	public sealed class AppConfig
	{
		public static AppMeta AppMeta { get; set; } = new AppMeta();

		public static MySQLSettings MySQLSettings { get; set; } = new MySQLSettings();

		public static RootCredentials RootCredentials { get; set; } = new RootCredentials();
	}
}