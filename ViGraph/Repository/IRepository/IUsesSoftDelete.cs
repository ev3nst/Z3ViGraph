using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViGraph.Repository.IRepository
{
    public interface IUsesSoftDelete<T> where T : class
    {
        bool SetUseRestoreButton(bool Status);

        bool SetUsePermaDeleteButton(bool Status);

        string RestoreLink(int Id);

        string PermaDeleteLink(int Id);

        string CreateRestoreButton(T Resource);

        string CreatePermaDeleteButton(T Resource);

        Task<IEnumerable<T>> paginateDeleted(PaginationOptions<T> PaginationOptions);
    }
}
