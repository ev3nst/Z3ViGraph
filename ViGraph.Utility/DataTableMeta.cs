using System.Collections.Generic;

namespace ViGraph.Utility
{
	public class DataTableMeta
	{
		public int from { get; set; }

		public int to { get; set; }

		public int total { get; set; }

		public string first_page_url { get; set; }

		public string last_page_url { get; set; }

		public string next_page_url { get; set; }

		public string prev_page_url { get; set; }

		public IEnumerable<string> links { get; set; }

		public int page { get; set; }

		public int pages { get; set; }

		public int last_page { get; set; }

		public int perpage { get; set; }

		public string field { get; set; }

		public string sort { get; set; }

		public string path { get; set; }
	}
}
