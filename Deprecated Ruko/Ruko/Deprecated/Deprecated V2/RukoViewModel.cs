using ControlsAndResources;
using Enums;
using Managers;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Utilities.Functions;

namespace Ruko
{
    public class RukoViewModel : ManagerViewModel<RukoWindow,RukoModel>
    {
        public static RukoViewModel Ruko { get; set; }
        #region Controls
        public RukoView RukoView => Window.RukoView;

        public GeneralView GeneralView => RukoView.GeneralView;
        public DataGrid CustomersGrid => GeneralView.CustomersGrid;

        public SpecificView SpecificView => RukoView.SpecificView;
        public ListView OpenedCustomersList => SpecificView.OpenedCustomersList;
        public CustomerView CustomerView => SpecificView.CustomerView;
        #endregion

        public ICommand OpenCustomerCommand { get; private set; }
        public ICommand CloseCustomerCommand { get; private set; }
        public ICommand DeactivateCustomerCommand { get; private set; }
        public ICommand DeleteCustomerCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand OpenCommand { get; private set; }
        public ICommand OpenAllCommand { get; private set; }
        public ICommand EditCustomerCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand CloseAllCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }

        public bool IsAddingNewCustomer
        {
            get => Model.isAddingNewCustomer;
            set
            {
                if (Model.isAddingNewCustomer != value)
                {
                    Model.isAddingNewCustomer = value;
                    OnPropertyChanged();
                }
            }
        }
        public NewCustomerViewModel NewCustomer
        {
            get => Model.newCustomer;
            set
            {
                if (Model.newCustomer != value)
                {
                    Model.newCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<CustomerViewModel> Customers { get; } = new ObservableCollection<CustomerViewModel>();
        public ObservableCollection<CustomerViewModel> OpenedCustomers { get; } = new ObservableCollection<CustomerViewModel>();

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
        public CustomerViewModel SelectedOpenedCustomer
        {
            get => Model.selectedOpenedCustomer;
            set
            {
                if (Model.selectedOpenedCustomer != value)
                {
                    Model.selectedOpenedCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        public IEnumerable<CustomerViewModel> SelectedCustomers
        {
            get => Model.selectedCustomers;
            set
            {
                if (Model.selectedCustomers != value)
                {
                    Model.selectedCustomers = value;
                    OnPropertyChanged();
                }
            }
        }
        public IEnumerable<CustomerViewModel> SelectedOpenedCustomers
        {
            get => Model.selectedOpenedCustomers;
            set
            {
                if (Model.selectedOpenedCustomers != value)
                {
                    Model.selectedOpenedCustomers = value;
                    OnPropertyChanged();
                }
            }
        }

        public double SelectedFontSize
        {
            get => Model.selectedFontSize;
            set
            {
                if (Model.selectedFontSize != value)
                {
                    Model.selectedFontSize = value;
                    OnPropertyChanged();
                }
            }
        }
        public double[] FontSizes
        {
            get => Model.fontSizes;
            set
            {
                if (Model.fontSizes != value)
                {
                    Model.fontSizes = value;
                    OnPropertyChanged();
                }
            }
        }

        public RukoViewModel(RukoWindow window, RukoModel model) : base(window, model, "Ruko")
        {
            Ruko = this;
        }

        public override void Initialize()
        {
            base.Initialize();
            InitializeFontSizes();
            CustomersGrid.SelectionChanged += (sender, e) =>
            {
                SelectedCustomers = e.AddedItems.OfType<CustomerViewModel>();
                foreach (CustomerViewModel customer in e.AddedItems)
                {
                    customer.IsSelected = true;
                }

                foreach (CustomerViewModel customer in e.RemovedItems)
                {
                    customer.IsSelected = false;
                }
            };
            OpenedCustomersList.SelectionChanged += (sender, e) =>
            {
                SelectedOpenedCustomers = e.AddedItems.OfType<CustomerViewModel>();
                foreach (CustomerViewModel customer in e.AddedItems)
                {
                    customer.IsOpenSelected = true;
                }

                foreach (CustomerViewModel customer in e.RemovedItems)
                {
                    customer.IsOpenSelected = false;
                }
            };
            Generate();
        }

        void InitializeFontSizes()
        {
            int sizesCount = 21;
            FontSizes = new double[sizesCount];
            for (int i = 0; i < sizesCount; i++)
            {
                FontSizes[i] = i;
            }
        }

        public override void InitializeCommands()
        {
            OpenCustomerCommand = new RelayCommand(() => SelectedCustomer?.Open());
            CloseCustomerCommand = new RelayCommand(() => SelectedCustomer?.Close());
            DeactivateCustomerCommand = new RelayCommand(() => SelectedCustomer?.ToggleActivation());
            DeleteCustomerCommand = new RelayCommand(() => SelectedCustomer?.Delete());
            AddCommand = new RelayCommand(() => NewCustomer = new NewCustomerViewModel(this, new NewCustomerModel()));
            //AddCommand = new RelayCommand(() =>
            //{
            //    IsAddingNewCustomer = true;
            //    NewCustomer = new NewCustomerViewModel(this, new NewCustomerModel());
            //});
            OpenCommand = new RelayCommand(() =>
            {
                foreach (CustomerViewModel customer in CustomersGrid.SelectedItems)
                {
                    customer.Open();
                }
            });
            OpenAllCommand = new RelayCommand(() =>
            {
                if (MessageBox.Show("This action will open every customer profile. Continue?", "Confirm action", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                {
                    foreach (CustomerViewModel customer in CustomersGrid.Items)
                    {
                        customer.Open();
                    }
                }
            });
            EditCustomerCommand = new RelayCommand<string>((infoTabIndex) => SelectedCustomer?.Edit(int.Parse(infoTabIndex)));
            //Due to collection mod during iteration you need to cast to a list and iterate 
            CloseCommand = new RelayCommand(() => (OpenedCustomersList.SelectedItem as CustomerViewModel).Close());
            CloseAllCommand = new RelayCommand(() =>
            {
                if (OpenedCustomersList.Items.Count > 0)
                {
                    MessageBoxResult result = MessageBox.Show("This action will close every customer profile. Continue?", "Confirm action", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        OpenedCustomersList.Items.OfType<CustomerViewModel>().ToList().ForEach(customer => customer.Close());
                    }
                }
            });
            ExitCommand = new RelayCommand(() => Window.Close());
        }
        #region Test Date
        void Generate()
        {
            GeneratePerson("Rigel Taylor Johnston", "1553 A St, Anchorage AK, 99501", "rxjohnston@gmail.com", "631-780-2905");
            GeneratePerson("Andrea Libucha", "6021 Rowanberry Dr, Elkridge MD, 21075", "alibucha1347@gmail.com", "441-744-7499");
            GeneratePerson("Gwen Johnston", "58 Oak St, Smithtown NY, 11787", "freedomoil@oponline.net", "631-265-2002");
            GeneratePerson("Glen Johnston", "58 Oak St, Smithtown NY, 11787", "freedomoil@oponline.net", "631-265-2002");
            GeneratePerson("Kaeleigh Johnston", "58 Oak St, Smithtown NY, 11787", "freedomoil@oponline.net", "631-265-2002");
            GeneratePerson("Nelson Gomez", "58 Oak St, Smithtown NY, 11787", "freedomoil@oponline.net", "631-265-2002");
        }

        void GeneratePerson(string name, string address, string email, string phone)
        {
            //Customers.Add(
            //    new CustomerViewModel(
            //        this
            //        , new CustomerModel(
            //            new OverviewModel()
            //            , new ContactModel(name, address, email, phone)
            //            , new AccountModel()
            //            , new ServiceModel()
            //            , new OilModel())));

            new CustomerViewModel(
                    this
                    , new CustomerModel(
                        new OverviewModel()
                        , new ContactModel(name, address, email, phone)
                        , new AccountModel()
                        , new ServiceModel()
                        , new OilModel())).Add();
        }
        #endregion
    }
}