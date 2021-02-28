using Contact.Mgmt.API.Data.Context;
using Contact.Mgmt.DataModel.Models;
using Contact.Mgmt.DataModel.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Mgmt.API.Repository
{
    public class ContactRepository: BaseRepository, IContactRepository
    {
        public ContactRepository(AppDbContext context): base(context) { }

        public async Task AddContactAsync(ContactInfo contact)
        {
            await _context.Contacts.AddAsync(contact);
        }

        public void DeleteContact(ContactInfo contact)
        {
            _context.Contacts.Remove(contact);
        }

        public async Task<IEnumerable<ContactInfo>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public void UpdateContactAsync(ContactInfo contact)
        {
            _context.Contacts.Update(contact);
        }

        public async Task<ContactInfo> FindByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }
    }
}
