using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class ContactModel
    {
        internal PrimaryAssociationPair<NameViewModel, NameModel> names;
        internal PrimaryAssociationPair<AddressViewModel, AddressModel> addresses;
        internal PrimaryAssociationPair<EmailViewModel, EmailModel> emails;
        internal PrimaryAssociationPair<PhoneViewModel, PhoneModel> phones;
        public ContactModel(NameModel name, AddressModel address, EmailModel email, PhoneModel phone)
        {
            names = new PrimaryAssociationPair<NameViewModel, NameModel>(name);
            addresses = new PrimaryAssociationPair<AddressViewModel, AddressModel>(address);
            emails = new PrimaryAssociationPair<EmailViewModel, EmailModel>(email);
            phones = new PrimaryAssociationPair<PhoneViewModel, PhoneModel>(phone);
        }
    }
}