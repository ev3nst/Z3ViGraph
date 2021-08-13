using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViGraph.Database.Repository.IRepository
{
	public interface IUsesPagination<T> {
        Task<IEnumerable<T>> Paginate(PaginationOptions PaginationOptions);

        void SetUseEditButton(bool Status);
        void SetUseDeleteButton(bool Status);

        string EditLink(int Id);

        string DeleteLink(int Id);

        string CreateEditButton(T Resource);

        string CreateDeleteButton(T Resource);

        string ActionsHTML(T Resource);

        void CheckButtonPermissions();
    }
}
