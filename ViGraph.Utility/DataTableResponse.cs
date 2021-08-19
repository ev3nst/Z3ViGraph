using System;
using System.Collections.Generic;

namespace ViGraph.Utility
{
	public class DataTableResponse<T>
	{
		public IEnumerable<T> data { get; set; }

		public int length { get; set; }

		public DataTableMeta meta { get; set; } = new DataTableMeta();

		public int recordsFiltered { get; set; }

		public int recordsTotal { get; set; }

        // get => (int)Math.Floor((decimal)recordsFiltered / (decimal)length);
		public int pages { get => recordsFiltered / length; }

		public string status { get; set; }

		public int statusCode { get; set; }

		public string message { get; set; }
	}
}
