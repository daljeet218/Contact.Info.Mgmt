using Contact.Mgmt.DataModel.Models;

namespace Contact.Mgmt.DataModel.ResponseHandler
{
    public class ResultHandler: BaseResult
    {
        public ContactInfo ContactInfo { get; set; }

        private ResultHandler(bool success, string message, ContactInfo contactinfo) : base(success, message)
        {
            ContactInfo = contactinfo;
        }

        //Success Response Handler
        public ResultHandler(ContactInfo contactinfo) : this(true, string.Empty, contactinfo) { }

        //Failure Response Handler
        public ResultHandler(string message) : this(false, message, null) { }
    }
}
