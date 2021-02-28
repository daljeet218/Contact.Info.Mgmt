using AutoMapper;
using Contact.Mgmt.DataModel.Interfaces;
using Contact.Mgmt.DataModel.Models;
using Contact.Mgmt.DataModel.Repositories;
using Contact.Mgmt.DataModel.ResponseHandler;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contact.Mgmt.ServiceGateways.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IServiceStatus _serviceStatus;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IServiceStatus serviceStatus, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _serviceStatus = serviceStatus;
            _mapper = mapper;
        }
        public async Task<ResultHandler> AddContactAsync(ContactInfo contact)
        {
            try
            {
                await _contactRepository.AddContactAsync(contact);
                await _serviceStatus.CompleteAsync();
                return new ResultHandler(contact);
            }
            catch(Exception ex)
            {
                return new ResultHandler($"An error occurred when adding the contact: {ex.Message}");
            }
        }

        public async Task<ResultHandler> DeleteContactAsync(int contactId)
        {
            var existingContact = await _contactRepository.FindByIdAsync(contactId);

            if (existingContact == null)
                return new ResultHandler("Contact not found.");

            try
            {
                _contactRepository.DeleteContact(existingContact);
                await _serviceStatus.CompleteAsync();
                return new ResultHandler(existingContact);
            }
            catch (Exception ex)
            {
                return new ResultHandler($"An error occurred when deleting the contact: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ContactInfo>> GetContactsAsync()
        {
            return await _contactRepository.GetContactsAsync();
        }

        public async Task<ResultHandler> UpdateContactAsync(int ContactId, ContactInfo contact)
        {
            var existingContact = await _contactRepository.FindByIdAsync(ContactId);
            if(existingContact == null)
            {
                return new ResultHandler("Contact does not exist.");
            }

            var contactEntity = GetMappedContact(existingContact, contact);

            try
            {
                _contactRepository.UpdateContactAsync(contactEntity);
                await _serviceStatus.CompleteAsync();
                return new ResultHandler(contactEntity);
            }
            catch (Exception ex)
            {
                return new ResultHandler($"An error occurred when updating the contact: {ex.Message}");
            }
        
        }

        private ContactInfo GetMappedContact(ContactInfo existingContact, ContactInfo requestContact)
        {

            existingContact.FirstName = requestContact.FirstName;
            existingContact.LastName = requestContact.LastName;
            existingContact.Email = requestContact.Email;
            existingContact.PhoneNumber = requestContact.PhoneNumber;
            existingContact.Status = requestContact.Status;
            return existingContact;
        }
    }
}
