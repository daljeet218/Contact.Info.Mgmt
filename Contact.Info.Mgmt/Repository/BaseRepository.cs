using Contact.Mgmt.API.Data.Context;

namespace Contact.Mgmt.API.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
