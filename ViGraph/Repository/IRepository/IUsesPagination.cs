using System.Threading.Tasks;

using ViGraph.Utility;

namespace ViGraph.Repository.IRepository
{
	public interface IUsesPagination<T, TDTO> where T : class
	{
		bool UseEditButton { get; set; }

		bool UseDeleteButton { get; set; }

		string EditLink(int Id);

		string DeleteLink(int Id);

		string CreateEditButton(int Id);

		string CreateDeleteButton(int Id, string Title);

		string ActionsHTML(TDTO Resource);

		void CheckButtonPermissions();

		Task<DataTableResponse<TDTO>> Paginate(PaginationOptions PaginationOptions);

        DataTableResponse<TDTO> ConfigureDataTableMeta(
            DataTableResponse<TDTO> dtResponse,
            PaginationOptions paginationOptions,
            string APIRoutePrefix
        );
	}
}
