using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Contact : SectionBase<ContactModel>
    {
        public Contact(Customer parent, ContactModel model) : base(parent, model)
        {
        }
    }

    public class ContactModel : SectionBaseModel
    {

    }
}