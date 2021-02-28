using AutoMapper;
using Contact.Mgmt.API.Extensions;
using Contact.Mgmt.API.Resources;
using Contact.Mgmt.DataModel.Interfaces;
using Contact.Mgmt.DataModel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Contact.Mgmt.API.Controllers
{
    [Route("/api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Description("Gets List of all Contacts.")]
        public async Task<IEnumerable<ContactInfo>> GetAllContactsAsync()
        {
            var contacts = await _contactService.GetContactsAsync();
            return contacts;
        }

        [HttpPost]
        [Description("Adds a Contact.")]
        public async Task<IActionResult> PostAsync([FromBody] AddContact newContact)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var contact = _mapper.Map<AddContact, ContactInfo>(newContact);
            var result = await _contactService.AddContactAsync(contact);

            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            var contactResource = _mapper.Map<ContactInfo, ContactResource>(result.ContactInfo);
            return Ok(contactResource);
        }

        [HttpPut("{contactId}")]
        [Description("Updates a Contact.")]
        public async Task<IActionResult> PutAsync(int contactId, [FromBody] AddContact newContact)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var contact = _mapper.Map<AddContact, ContactInfo>(newContact);
            var result = await _contactService.UpdateContactAsync(contactId, contact);

            if (!result.Success)
                return BadRequest(result.Message);

            var contactResource = _mapper.Map<ContactInfo, ContactResource>(result.ContactInfo);
            return Ok(contactResource);

        }

        [HttpDelete("{contactId}")]
        [Description("Deletes a Contact.")]
        public async Task<IActionResult> DeleteAsync(int contactId)
        {
            var result = await _contactService.DeleteContactAsync(contactId);

            if (!result.Success)
                return BadRequest(result.Message);

            var contactResource = _mapper.Map<ContactInfo, ContactResource>(result.ContactInfo);
            return Ok(contactResource);
        }
    }
}
