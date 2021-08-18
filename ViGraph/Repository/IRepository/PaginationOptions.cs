namespace ViGraph.Repository.IRepository
{
	public enum SortOrderTypes
	{
		ASC,
		DESC
	}

	public class PaginationOptions
	{
		public int PerPage { get; set; }

		public int Page { get; set; }

		public string SortField { get; set; }

		public SortOrderTypes SortOrder { get; set; } = SortOrderTypes.DESC;

		public string QueryString { get; set; } = null;

		public int Offset { get => Page <= 1 ? 0 : Page * PerPage; }
	}
}
