using System.Collections.Generic;

namespace ViGraph.Database.Repository.IRepository
{
    public enum SortOrderTypes {
        ASC,
        DESC
    }

    public class PaginationOptions
    {
        public int PerPage { get; set; }

        public int Page { get; set; }

        public string QueryString { get; set; } = null;

        public string SearchKey { get; set; } = null;

        public string SortField { get; set; }

        public SortOrderTypes SortOrder { get; set; } = SortOrderTypes.DESC;
    }
}
