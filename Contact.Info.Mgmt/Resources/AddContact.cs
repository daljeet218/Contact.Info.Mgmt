using Contact.Mgmt.DataModel.Enums;
using System.ComponentModel.DataAnnotations;

namespace Contact.Mgmt.API.Resources
{
    public class AddContact
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        public EContactStatus Status { get; set; }
    }
}
