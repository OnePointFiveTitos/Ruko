using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Ruko
{
    public class ContactModel
    {
        internal NameViewModel name;
        internal AddressViewModel address;
        internal AddressViewModel additionalAddress;
        internal EmailViewModel email;
        internal PhoneViewModel phone;
        internal PreferredContactTypes preferredContactType;
        internal bool isSameBillAndMailTo;
        //public ContactModel(Name name, Address address, Email email, Phone phone)
        //{
        //    this.name = name;
        //    this.address = address;
        //    this.email = email;
        //    this.phone = phone;
        //}
    }
}