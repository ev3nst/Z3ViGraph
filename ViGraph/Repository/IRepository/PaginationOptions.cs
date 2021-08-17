namespace ViGraph.Repository.IRepository
{
    public enum SortOrderTypes {
        ASC,
        DESC
    }

    public class PaginationOptions<T> where T : class
    {
        public int PerPage { get; set; }

        public int Page { get; set; }

        public string QueryString { get; set; } = null;

        public string SearchKey { get; set; } = null;

        public string SortField { get; set; }

        public int Offset { get => Page <= 1 ? 0 : Page * PerPage; }

        public SortOrderTypes SortOrder { get; set; } = SortOrderTypes.DESC;
    }
}
