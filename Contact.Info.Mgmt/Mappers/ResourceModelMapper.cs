using AutoMapper;
using Contact.Mgmt.API.Resources;
using Contact.Mgmt.DataModel.Models;

namespace Contact.Mgmt.API.Mappers
{
    public class ResourceModelMapper: Profile
    {
        public ResourceModelMapper()
        {
            CreateMap<AddContact, ContactInfo>();
            CreateMap<ContactInfo, ContactResource>();
        }
    }
}
