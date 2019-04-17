using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Phone : NodeViewModel<Customer, PhoneModel>
    {
        public Phone(Customer parent, PhoneModel model) : base(parent, model)
        {
        }
    }

    public class PhoneModel
    {

    }
}