using ViGraph.Models;
using ViGraph.Models.DTO;

namespace ViGraph.Repository.IRepository
{
    public interface IAppRoleRepository : IRepository<AppRole, AppRoleDTO>, IUsesSoftDelete<AppRoleDTO>
    {
    }
}
