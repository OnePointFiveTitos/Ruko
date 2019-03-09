using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using static Utilities.Functions;

namespace Ruko
{
    public class AccountViewModel : MainInfoViewModel<AccountModel>
    {
        public static Dictionary<string, Dictionary<int, bool>> IDs { get; set; } = new Dictionary<string, Dictionary<int, bool>>();
        static AccountViewModel()
        {
            //load ids here OR when loading customer list make sure their ids are loaded into this list
        }

        public static void GenerateNewID(CustomerViewModel customer)
        {
            int number = 0;
            customer.Contact.Name.Evaluate();
            string initials = customer.Contact.Name.Initials;
            if (!IDs.ContainsKey(initials))
            {
                IDs.Add(initials, new Dictionary<int, bool>());
                for (int i = 1000; i < 10000; i++)
                {
                    IDs[initials].Add(i, false);
                }
            }
            number = IDs[initials].First(kvp => !kvp.Value).Key;
            IDs[initials][number] = true;
            customer.Account.ID = $"{initials}-{number}";
        }
        public static void ResetID(CustomerViewModel customer)
        {
            IDs[customer.Contact.Name.Initials][int.Parse(customer.Account.ID.Substring(3))] = false;
        }
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
        public string Status
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
        public string Standing
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
        public string Lead
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

        public AccountViewModel(CustomerViewModel parent, AccountModel model) : base(parent, model)
        {
        }
    }
}