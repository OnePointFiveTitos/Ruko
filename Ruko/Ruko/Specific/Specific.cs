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
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace Ruko
{
    public class SpecificViewModel : NodeViewModel<RukoViewModel, SpecificModel>, ICustomerContainer
    {
        public SpecificView SpecificView => Parent.RukoView.SpecificView;
        public ListBox SpecificCustomersList => SpecificView.SpecificCustomersList;

        //public ObservableCollection<CustomerViewModel> SpecificCustomers { get; } = new ObservableCollection<CustomerViewModel>();
        //public CustomerViewModel SelectedSpecificCustomer
        //{
        //    get => Model.selectedCustomer;
        //    set
        //    {
        //        if (Model.selectedCustomer != value)
        //        {
        //            Model.selectedCustomer = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        public ObservableCollection<CustomerViewModel> Customers { get; } = new ObservableCollection<CustomerViewModel>();
        public CustomerViewModel SelectedCustomer
        {
            get => Model.selectedCustomer;
            set
            {
                if (Model.selectedCustomer != value)
                {
                    Model.selectedCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CloseCommand { get; private set; }
        public ICommand CloseAllCommand { get; private set; }

        public SpecificViewModel(RukoViewModel parent, SpecificModel model) : base(parent, model)
        {
            Initialize();
        }
        public void Initialize()
        {
            Customers.CollectionChanged += (sender, e) =>
            {
                SelectedCustomer = SelectedCustomer ?? Customers.FirstOrDefault();
            };
        }
        public override void InitializeCommands()
        {
            base.InitializeCommands();
            //CloseCommand = new RelayCommand(() => SelectedCustomer?.ToggleProfileState(false));
            CloseCommand = new RelayCommand(() => SelectedCustomer?.Close());
            CloseAllCommand = new RelayCommand(() =>
            {
                if (SpecificCustomersList.Items.Count > 0)
                {
                    if (MessageBox.Show("Close all customer profiles?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        //SpecificCustomersList.Items.OfType<CustomerViewModel>().ToList().ForEach(customer => customer.ToggleProfileState(false));
                        SpecificCustomersList.Items.OfType<CustomerViewModel>().ToList().ForEach(customer => customer.Close());
                    }
                }
            });
        }
    }

    public class SpecificModel
    {
        internal CustomerViewModel selectedCustomer;
    }

    public interface ICustomerContainer
    {
        ObservableCollection<CustomerViewModel> Customers { get; }
        CustomerViewModel SelectedCustomer { get; set; }
    }
}