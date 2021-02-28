using System.Collections.Generic;
using System.Threading.Tasks;
using Contact.Mgmt.DataModel.Models;
using Contact.Mgmt.DataModel.ResponseHandler;

namespace Contact.Mgmt.DataModel.Interfaces
{
    public interface IContactService
    {
        public Task<IEnumerable<ContactInfo>> GetContactsAsync();
        public Task<ResultHandler> AddContactAsync(ContactInfo contact);
        public Task<ResultHandler> UpdateContactAsync(int ContactId, ContactInfo contact);
        public Task<ResultHandler> DeleteContactAsync(int ContactId);
    }
}
