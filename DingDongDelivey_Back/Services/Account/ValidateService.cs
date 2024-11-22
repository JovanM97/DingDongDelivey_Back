using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DingDongDelivey_Back.Services.Account
{
    public class ValidateService
    {
        public bool ValidateStringInCollection(string value, ICollection<string> collection)
        {
            return collection.Contains(value);
        }
        public bool ValidateEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
        public bool CompareString(string value1, string value2)
        {
            return value1.Equals(value2); //&&value1!=null && !value1.Equals(string.Empty)&&value2 != null && !value2.Equals(string.Empty);
        }

    }
}
