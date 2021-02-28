using Contact.Mgmt.API.Resources;
using Contact.Mgmt.DataModel.Enums;
using Contact.Mgmt.DataModel.Models;
using System.Collections.Generic;

namespace Contact.Mgmt.UnitTest.MockData
{
    public static class ServiceMock
    {
        public static AddContact GetAddContactRequest()
        {
            return new AddContact
            {
                FirstName = "spider",
                LastName = "man",
                Email = "spiderman@avengers.com",
                PhoneNumber = "9999977777",
                Status = EContactStatus.Active
            };
        }

        public static AddContact GetInvalidAddContactRequest()
        {
            return new AddContact
            {
                FirstName = "spider",
                LastName = "",
                Email = "spiderman@avengers.com",
                PhoneNumber = "9999977777",
                Status = EContactStatus.Active
            };
        }

        public static ContactInfo GetContact()
        {
            return new ContactInfo
            {
                FirstName = "spider",
                LastName = "man",
                Email = "spiderman@avengers.com",
                PhoneNumber = "9999977777",
                Status = EContactStatus.Active
            };
        }

        public static IEnumerable<ContactInfo> GetAllContacts()
        {
            return new List<ContactInfo>()
            {
                new ContactInfo() {
                Id = 100, 
                FirstName = "spider", 
                LastName = "man", 
                Email = "spiderman@avengers.com", 
                PhoneNumber = "9999977777", 
                Status = EContactStatus.Active}
            };
        }

        public static int GetExistingContactRequest()
        {
            return 100;
        }

        public static int GetNonExistingContactRequest()
        {
            return 110;
        }
    }
}
