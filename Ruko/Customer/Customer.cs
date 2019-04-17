using Xne_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Customer : NodeViewModel<RukoViewModel, CustomerModel>
    {
        public Customer(RukoViewModel parent, CustomerModel model) : base(parent, model)
        {
        }
    }

    public class CustomerModel
    {

    }
}