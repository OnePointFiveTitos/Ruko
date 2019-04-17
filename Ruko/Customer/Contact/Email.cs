using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Email : NodeViewModel<Customer, EmailModel>
    {
        public Email(Customer parent, EmailModel model) : base(parent, model)
        {
        }
    }

    public class EmailModel
    {

    }
}