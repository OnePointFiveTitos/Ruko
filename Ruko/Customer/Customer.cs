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
        public Account Account => Model.account;
        public Contact Contact => Model.contact;
        public Oil Oil => Model.oil;
        public Service Service => Model.service;
        public Customer(RukoViewModel parent, CustomerModel model) : base(parent, model)
        {
        }
    }

    public class CustomerModel
    {
        internal Account account;
        internal Contact contact;
        internal Oil oil;
        internal Service service;
        public CustomerModel(Account account, Contact contact, Oil oil, Service service)
        {
            this.account = account;
            this.contact = contact;
            this.oil = oil;
            this.service = service;
        }
    }
}