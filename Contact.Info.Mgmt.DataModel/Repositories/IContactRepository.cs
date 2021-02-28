using Contact.Mgmt.DataModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Mgmt.DataModel.Repositories
{
    public interface IContactRepository
    {
        public Task<IEnumerable<ContactInfo>> GetContactsAsync();
        public Task AddContactAsync(ContactInfo contact);
        public void UpdateContactAsync(ContactInfo contact);
        public Task<ContactInfo> FindByIdAsync(int contactId);
        public void DeleteContact(ContactInfo contact);


    }
}
