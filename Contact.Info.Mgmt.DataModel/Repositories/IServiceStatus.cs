using System.Threading.Tasks;

namespace Contact.Mgmt.DataModel.Repositories
{
    public interface IServiceStatus
    {
        Task CompleteAsync();
    }
}
