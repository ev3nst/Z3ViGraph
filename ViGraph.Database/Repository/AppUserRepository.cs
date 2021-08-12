using ViGraph.Models;
using ViGraph.Database.Repository.IRepository;

namespace ViGraph.Database.Repository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly ApplicationDbContext _db;
        public AppUserRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

    }
}
