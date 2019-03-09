using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVM;

namespace Ruko
{
    public class NewCustomerViewModel : NodeViewModel<RukoViewModel, NewCustomerModel>
    {
        public ICommand CreateCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public CustomerViewModel Customer
        {
            get => Model.customer;
            set
            {
                if (Model.customer != value)
                {
                    Model.customer = value;
                    OnPropertyChanged();
                }
            }
        }

        public NewCustomerViewModel(RukoViewModel parent, NewCustomerModel model) : base(parent, model)
        {
            Customer = new CustomerViewModel(Parent, new CustomerModel(new OverviewModel(), new ContactModel(), new AccountModel(), new ServiceModel(), new OilModel()));
            Parent.IsAddingNewCustomer = true;
        }

        public override void InitializeCommands()
        {
            CreateCommand = new RelayCommand(() =>
            {
                Customer.Add();
                Parent.IsAddingNewCustomer = false;
            });
            ResetCommand = new RelayCommand(() => Customer = new CustomerViewModel(Parent, new CustomerModel(new OverviewModel(), new ContactModel(), new AccountModel(), new ServiceModel(), new OilModel())));
            CancelCommand = new RelayCommand(() =>
            {
                Customer = null;
                Parent.IsAddingNewCustomer = false;
            });
        }
    }
}