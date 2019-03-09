using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class ContactModel : MainInfoModel
    {
        internal NameModel name;
        internal AddressModel address;
        internal EmailModel email;
        internal PhoneModel phone;

        public ContactModel(string name = null, string address = null, string email = null, string phone = null)
        {
            this.name = new NameModel(name);
            this.address = new AddressModel(address);
            this.email = new EmailModel(email);
            this.phone = new PhoneModel(phone);
        }

        public ContactModel(NameModel name, AddressModel address, EmailModel email, PhoneModel phone)
        {
            this.name = name;
            this.address = address;
            this.email = email;
            this.phone = phone;
        }
    }
}