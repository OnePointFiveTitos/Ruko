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
    public class SpecificViewModel : NodeViewModel<RukoViewModel, SpecificModel>
    {
        public SpecificView SpecificView => Parent.RukoView.SpecificView;
        public ListBox SpecificCustomersList => SpecificView.SpecificCustomersList;

        public ObservableCollection<CustomerViewModel> SpecificCustomers { get; } = new ObservableCollection<CustomerViewModel>();
        public CustomerViewModel SelectedSpecificCustomer
        {
            get => Model.selectedSpecificCustomer;
            set
            {
                if (Model.selectedSpecificCustomer != value)
                {
                    Model.selectedSpecificCustomer = value;
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
            SpecificCustomers.CollectionChanged += (sender, e) =>
            {
                SelectedSpecificCustomer = SelectedSpecificCustomer ?? SpecificCustomers.FirstOrDefault();
            };
        }
        public override void InitializeCommands()
        {
            base.InitializeCommands();
            CloseCommand = new RelayCommand(() => SelectedSpecificCustomer?.ToggleProfileState(false));
            CloseAllCommand = new RelayCommand(() =>
            {
                if (SpecificCustomersList.Items.Count > 0)
                {
                    if (MessageBox.Show("Close all customer profiles?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        SpecificCustomersList.Items.OfType<CustomerViewModel>().ToList().ForEach(customer => customer.ToggleProfileState(false));
                    }
                }
            });
        }
    }

    public class SpecificModel
    {
        internal CustomerViewModel selectedSpecificCustomer;
    }
}