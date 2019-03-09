using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ruko
{
    public class ContactViewModel : NodeViewModel<CustomerViewModel, ContactModel>
    {
        public PrimaryAssociationPair<NameViewModel, NameModel> Names => Model.names;
        public PrimaryAssociationPair<AddressViewModel, AddressModel> Addresses => Model.addresses;
        public PrimaryAssociationPair<EmailViewModel, EmailModel> Emails => Model.emails;
        public PrimaryAssociationPair<PhoneViewModel, PhoneModel> Phones => Model.phones;
        public ContactViewModel(CustomerViewModel parent, ContactModel model) 
            : base(parent, model)
        {
            //Names.Add(name);
            //Addresses.Add(address);
            //Emails.Add(email);
            //Phones.Add(phone);
        }
    }
}