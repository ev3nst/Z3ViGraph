using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViGraph.Repository.IRepository
{
	public interface IUsesPagination<T> {
        Task<IEnumerable<T>> Paginate(PaginationOptions PaginationOptions);

        bool UseEditButton { get; set; }

        bool UseDeleteButton { get; set; }

        string EditLink(int Id);

        string DeleteLink(int Id);

        string CreateEditButton(T Resource);

        string CreateDeleteButton(T Resource);

        string ActionsHTML(T Resource);

        void CheckButtonPermissions();
    }
}
