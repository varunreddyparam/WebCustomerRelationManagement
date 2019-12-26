using System;
using System.Linq;
using WebCustomerRelationManagement.Interface;
using WebCustomerRelationManagement.Models;

namespace WebCustomerRelationManagement.Concrete
{
    public class PhoneNumberConcrete : IPhoneNumber
    {
        public IQueryable<PhoneNumber> GetPhoneNumberByContact(Guid contactId, string contactType)
        {
            var _Context = new DatabaseContext();
            var phoneNumberDeatil = (from phoneNumber in _Context.PhoneNumbers
                                     where phoneNumber.CustomerType == contactId &&
                                     phoneNumber.CustomerTypeName == contactType
                                     select phoneNumber);
            return phoneNumberDeatil;
        }
    }
}
