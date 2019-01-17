using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace Ruko
{
    public class ContactViewModel : MainInfoViewModel<ContactModel>
    {
        public NameViewModel Name { get; private set; }
        public AddressViewModel Address { get; private set; }
        public EmailViewModel Email { get; private set; }
        public PhoneViewModel Phone { get; private set; }

        public ContactViewModel(CustomerViewModel parent, ContactModel model) : base(parent, model)
        {
            Name = new NameViewModel(this, model.name);
            Address = new AddressViewModel(this, model.address);
            Email = new EmailViewModel(this, model.email);
            Phone = new PhoneViewModel(this, model.phone);
        }
    }
}