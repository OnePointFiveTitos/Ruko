using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using MVVM;

namespace Ruko
{
    public class AccountViewModel : NodeViewModel<CustomerViewModel, AccountModel>
    {
        public AccountTypes AccountType
        {
            get => Model.accountType;
            set
            {
                if (Model.accountType!=value)
                {
                    Model.accountType = value;
                    OnPropertyChanged();
                }
            }
        }
        public CustomerStatusTypes StatusType
        {
            get => Model.statusType;
            set
            {
                if (Model.statusType != value)
                {
                    Model.statusType = value;
                    OnPropertyChanged();
                }
            }
        }
        public AccountViewModel(CustomerViewModel parent, AccountModel model) 
            : base(parent, model)
        {
        }
    }
}