using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViGraph.Repository.IRepository
{
	public interface IUsesPagination<T> where T : class
	{
		bool UseEditButton { get; set; }

		bool UseDeleteButton { get; set; }

		string EditLink(int Id);

		string DeleteLink(int Id);

		string CreateEditButton(int Id);

		string CreateDeleteButton(int Id, string Title);

		string ActionsHTML(T Resource);

		Task CheckButtonPermissions();

		Task<IEnumerable<T>> Paginate(PaginationOptions PaginationOptions);
	}
}
