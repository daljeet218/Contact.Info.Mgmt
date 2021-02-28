using Contact.Mgmt.DataModel.Enums;

namespace Contact.Mgmt.DataModel.Models
{
    public class ContactResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public EContactStatus Status { get; set; }
    }
}
