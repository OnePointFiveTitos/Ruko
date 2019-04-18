using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Account : NodeViewModel<Customer, AccountModel>
    {
        public Account(Customer parent, AccountModel model) : base(parent, model)
        {
        }
    }

    public class AccountModel
    {
        internal string id;
        internal string status;
        internal string standing;
        internal string lead;
    }
}