using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Name : NodeViewModel<Customer, NameModel>
    {
        public Name(Customer parent, NameModel model) : base(parent, model)
        {
        }
    }

    public class NameModel
    {
        internal string first;
        internal string middle;
        internal string last;
    }
}