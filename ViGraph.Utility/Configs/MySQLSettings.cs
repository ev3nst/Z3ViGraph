namespace ViGraph.Utility.Configs
{
	public sealed class MySQLSettings
	{
		public string MySQLVersion { get; set; } = "auto";

		public int MaxBatchSize { get; set; } = 512;

		public int RetryOnFail { get; set; } = 0;
	}
}