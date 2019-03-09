using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Functions;
using static Utilities.Regexes;
using Enums;
using MVVM;
using Managers;
using System.Windows.Input;
namespace Ruko
{
    public class AccountViewModel : InfoViewModel<AccountModel>
    {
        public string ID
        {
            get => Model.id;
            set
            {
                if (Model.id != value)
                {
                    Model.id = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserParameter Status
        {
            get => Model.status;
            set
            {
                if (Model.status != value)
                {
                    Model.status = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserParameter Standing
        {
            get => Model.standing;
            set
            {
                if (Model.standing != value)
                {
                    Model.standing = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserParameter Lead
        {
            get => Model.lead;
            set
            {
                if (Model.lead != value)
                {
                    Model.lead = value;
                    OnPropertyChanged();
                }
            }
        }

        public AccountViewModel(CustomerViewModel parent, AccountModel model) : base(parent, model, "Account")
        {
            //Model = Model ?? new AccountModel();
        }
    }

    public class AccountModel : InfoModel
    {
        internal string id;
        internal UserParameter status;
        internal UserParameter standing;
        internal UserParameter lead;

        public AccountModel()
        {

        }
        public AccountModel(string id, UserParameter status, UserParameter standing, UserParameter lead)
        {
            this.id = id;
            this.status = status;
            this.standing = standing;
            this.lead = lead;
        }
    }
}