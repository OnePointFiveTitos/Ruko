using System.Linq;
using MVVM;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;

namespace Ruko
{
    public class GeneralViewModel : NodeViewModel<RukoViewModel, GeneralModel>, ICustomersContainer
    {
        public GeneralView GeneralView => Parent.RukoView.GeneralView;
        public DataGrid GeneralCustomersGrid => GeneralView.GeneralCustomersGrid;

        public ObservableCollection<CustomerViewModel> SelectedCustomers { get; } = new ObservableCollection<CustomerViewModel>();
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

        public int CustomerCount
        {
            get => Model.customerCount;
            set
            {
                if (Model.customerCount != value)
                {
                    Model.customerCount = value;
                    OnPropertyChanged();
                }
            }
        }
        public int SelectedCustomerCount
        {
            get => Model.selectedCustomerCount;
            set
            {
                if (Model.selectedCustomerCount != value)
                {
                    Model.selectedCustomerCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool AreAllSelected
        {
            get => Model.areAllSelected;
            set
            {
                if (Model.areAllSelected != value)
                {
                    Model.areAllSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToggleSelectionCommand { get; private set; }
        public ICommand DebugAddCommand { get; private set; }
        public ICommand OpenCommand { get; private set; }
        public ICommand OpenAllCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public GeneralViewModel(RukoViewModel parent, GeneralModel model) : base(parent, model)
        {
            Initialize();
        }

        public void Initialize()
        {
            Customers.CollectionChanged += (sender, e) =>
            {
                ReevaluateAreAllSelected();
                SelectedCustomer = SelectedCustomers.FirstOrDefault();
                CustomerCount = Customers.Count;
            };
            SelectedCustomers.CollectionChanged += (sender, e) =>
            {
                SelectedCustomerCount = SelectedCustomers.Count;
            };
            DebugAddCommand.Execute("10");
        }

        public override void InitializeCommands()
        {
            base.InitializeCommands();
            ToggleSelectionCommand = new RelayCommand<bool>((isChecked) =>
            {
                foreach (CustomerViewModel customer in Customers)
                {
                    customer.ToggleSelectState(isChecked, SelectionTypes.General, this);
                    //customer.ToggleSelectionState(isChecked, SelectionTypes.General);
                }
            });
            DebugAddCommand = new RelayCommand<string>((count) =>
            {
                for (int i = 0; i < int.Parse(count); i++)
                {
                    AddCommand.Execute(null);
                }
            });
            AddCommand = new RelayCommand(() => Customers.Add(new CustomerViewModel(Parent)));
            OpenCommand = new RelayCommand(() =>
            {
                if (SelectedCustomers.Count > 1)
                {
                    if (MessageBox.Show("Open all selected customer profiles?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                    {
                        //SelectedCustomers.ToList().ForEach(customer => customer.ToggleProfileState(true, true));
                        SelectedCustomers.ToList().ForEach(customer => customer.Open(true));
                    }
                }
                else
                {
                    //SelectedCustomers.FirstOrDefault()?.ToggleProfileState(true, true);
                    SelectedCustomers.FirstOrDefault()?.Open(true);
                }
            });
            OpenAllCommand = new RelayCommand(() =>
            {
                if (MessageBox.Show("Open all profiles?", "Confirm", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    foreach (CustomerViewModel customer in GeneralCustomersGrid.Items.OfType<CustomerViewModel>())
                    {
                        //customer.ToggleProfileState(true, true);
                        customer.Open(true);
                    }
                }
            });
        }
        public void ReevaluateAreAllSelected()
        {
            AreAllSelected = SelectedCustomers.Count() == GeneralCustomersGrid.Items.Count;
        }
    }

    public class GeneralModel
    {
        internal CustomerViewModel selectedCustomer;
        internal bool areAllSelected = false;
        internal int customerCount;
        internal int selectedCustomerCount;
    }
}