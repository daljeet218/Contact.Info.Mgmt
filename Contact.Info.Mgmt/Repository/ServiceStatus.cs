using Contact.Mgmt.API.Data.Context;
using Contact.Mgmt.DataModel.Repositories;
using System.Threading.Tasks;

namespace Contact.Mgmt.API.Repository
{
    public class ServiceStatus: IServiceStatus
    {
        private readonly AppDbContext _context;
        public ServiceStatus(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
