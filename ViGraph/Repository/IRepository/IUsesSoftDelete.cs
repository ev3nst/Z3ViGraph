using System.Collections.Generic;
using System.Threading.Tasks;

using ViGraph.Utility;

namespace ViGraph.Repository.IRepository
{
    public interface IUsesSoftDelete<T> where T : class
    {
		bool UseRestoreButton { get; set; }

		bool UsePermaDeleteButton { get; set; }

        string RestoreLink(int Id);

        string PermaDeleteLink(int Id);

        string CreateRestoreButton(int Id);

        string CreatePermaDeleteButton(int Id, string Title);

        Task<DataTableResponse<T>> PaginateDeleted(PaginationOptions PaginationOptions);
    }
}
