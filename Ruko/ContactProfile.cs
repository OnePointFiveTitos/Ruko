using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class ContactProfile : NodeViewModel<Contact, ContactProfileModel>
    {
        //primary
        //associated collections (observable)
        public ContactProfile(Contact parent, ContactProfileModel model) : base(parent, model)
        {
        }
    }

    public class ContactProfileModel
    {
        internal Name name;
        internal Address address;
        internal Email email;
        internal Phone phone;
    }
}