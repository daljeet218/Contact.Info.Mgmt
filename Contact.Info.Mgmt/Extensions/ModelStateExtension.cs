using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace Contact.Mgmt.API.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(res => res.Value.Errors)
                             .Select(res => res.ErrorMessage)
                             .ToList();
        }
    }
}
