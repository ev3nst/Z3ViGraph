using ViGraph.Models;
using ViGraph.Models.DTO;

namespace ViGraph.Repository.IRepository
{
    public interface IAppUserRepository : IRepository<AppUser, AppUserDTO>, IUsesSoftDelete<AppUserDTO>
    {
    }
}
