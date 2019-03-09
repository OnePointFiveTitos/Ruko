using ControlsAndResources;
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
    /*Hierarchy
     * RukoViewModel
     * -HomeViewModel
     * -CustomerViewModel
     * --ContactViewModel
     * ---Name,Phone,Email,Address ViewModels
     * --ServiceViewModel
     */
    public class RukoViewModel : ViewModel<RukoModel>
    {
        public RukoManager Manager { get; }
        #region Controls
        public RukoWindow RukoWindow => Manager.Window;
        public RukoView RukoView => RukoWindow.RukoView;
        public GeneralView GeneralView => RukoView.GeneralView;
        public DataGrid CustomersGrid => GeneralView.CustomersGrid.Content as DataGrid;
        public CustomerTabs CustomerTabs => RukoView.CustomerTabs;
        public CustomerView CustomerView => CustomerTabs.CustomerView;
        public ContactView ContactView => CustomerView.ContactView;
        public ServiceView ServiceView => CustomerView.ServiceView;
        public TabControl CustomerViewTabs => CustomerView.CustomerViewTabs;
        #endregion
        public bool IsAddingCustomer
        {
            get => Model.isAddingCustomer;
            set
            {
                if (Model.isAddingCustomer != value)
                {
                    Model.isAddingCustomer = value;
                    OnPropertyChanged();
                }
            }
        }
        public AddCustomerViewModel AddCustomerViewModel
        {
            get => Model.addCustomerViewModel;
            set
            {
                if (Model.addCustomerViewModel != value)
                {
                    Model.addCustomerViewModel = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand AddCommand { get; private set; }
        public ICommand OpenCommand { get; private set; }
        public ICommand ModifyCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand RemoveCommand { get; private set; }
        public ICommand CloseAllCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ObservableCollection<TabItem> Tabs { get; } = new ObservableCollection<TabItem>();
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
                    CustomerViewTabs.SelectedIndex = value?.SelectedViewTabIndex ?? 0;
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
        public RukoViewModel(RukoManager manager, RukoModel model) 
            : base(model)
        {
            Manager = manager;
            GenerateTestData();
        }
        public void AddOpenedCustomer(CustomerViewModel customer)
        {
            if (!OpenedCustomers.Contains(customer))
            {
                OpenedCustomers.Add(customer);
            }
            SelectedOpenedCustomer = customer;
        }
        public override void InitializeCommands()
        {
            AddCommand = new RelayCommand(() =>
            {
                AddCustomerViewModel = new AddCustomerViewModel(this, new AddCustomerModel());
                IsAddingCustomer = true;
            });

            OpenCommand = new RelayCommand(() =>
            {
                if (CustomersGrid.SelectedItems.Count > 1)
                {
                    foreach (CustomerViewModel customer in CustomersGrid.SelectedItems.OfType<CustomerViewModel>())
                    {
                        AddOpenedCustomer(customer);
                    }
                }
                else
                {
                    AddOpenedCustomer(SelectedCustomer);
                }
            });
            ModifyCommand = new RelayCommand<string>((index) =>
            {
                if (SelectedCustomer != null)
                {
                    AddOpenedCustomer(SelectedCustomer);
                    SelectedCustomer.IsModifying = true;
                    SelectedCustomer.SelectedViewTabIndex = int.Parse(index ?? "1");
                    SelectedOpenedCustomer = SelectedCustomer;
                }
            });
            CancelCommand = new RelayCommand(() => IsAddingCustomer = false);
            CloseAllCommand = new RelayCommand(() => OpenedCustomers.Clear());
            RemoveCommand = new RelayCommand(() =>
            {
                if (MessageBox.Show("Are you sure you want to delete this customer from the database?", "Confirm removal", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Customers.Remove(SelectedCustomer);
                }
            });
            ExitCommand = new RelayCommand(() => RukoWindow.Close());
        }

        #region Generate Test Data
        //TODO: You need to figure out how to better instantiate these chain viewmodels. This is absolutely disgusting
        public void GenerateTestData()
        {
            GenerateRigel();
            //GenerateAndrea();
            //GenerateGwen();
            //GenerateGlen();
            //GenerateKaeleigh();
            //GenerateNelson();
        }
        public void GenerateRigel()
        {
            CustomerViewModel customer = new CustomerViewModel(this, new CustomerModel());
            ContactViewModel contact = new ContactViewModel(customer, new ContactModel());
            NameViewModel name = new NameViewModel(contact, new NameModel("Rigel Taylor Johnston"));
            AddressViewModel address = new AddressViewModel(contact, new AddressModel("1553 A St, Anchorage AK, 99501"));
            EmailViewModel email = new EmailViewModel(contact, new EmailModel("rxjohnston@gmail.com"));
            PhoneViewModel phone = new PhoneViewModel(contact, new PhoneModel("631-780-2905"));

            contact.Name = name;
            contact.Address = address;
            contact.Email = email;
            contact.Phone = phone;
            //contact.Names.Add(name);
            //contact.Addresses.Add(address);
            //contact.Emails.Add(email);
            //contact.Phones.Add(phone);
            customer.Contact = contact;
            Customers.Add(customer);
        }
        //public void GenerateAndrea()
        //{
        //    CustomerViewModel customer = new CustomerViewModel(this, new CustomerModel());
        //    ContactViewModel contact = new ContactViewModel(customer, new ContactModel());
        //    NameViewModel name = new NameViewModel(contact, "Andrea Libucha");
        //    AddressViewModel address = new AddressViewModel(contact, "6021 Rowanberry Dr, Elkridge MD, 21725");
        //    EmailViewModel email = new EmailViewModel(contact, "alibucha1347@gmail.com");
        //    PhoneViewModel phone = new PhoneViewModel(contact, "441-744-7449");

        //    contact.Name = name;
        //    contact.Address = address;
        //    contact.Email = email;
        //    contact.Phone = phone;
        //    //contact.Names.Add(name);
        //    //contact.Addresses.Add(address);
        //    //contact.Emails.Add(email);
        //    //contact.Phones.Add(phone);
        //    customer.Contact = contact;
        //    Customers.Add(customer);
        //}
        //public void GenerateGwen()
        //{
        //    CustomerViewModel customer = new CustomerViewModel(this, new CustomerModel());
        //    ContactViewModel contact = new ContactViewModel(customer, new ContactModel());
        //    NameViewModel name = new NameViewModel(contact, "Gwen Johnston");
        //    AddressViewModel address = new AddressViewModel(contact, "58 Oak St, Smithtown NY, 11787");
        //    EmailViewModel email = new EmailViewModel(contact, "nelgnewg@optonline.net");
        //    PhoneViewModel phone = new PhoneViewModel(contact, "631-265-2002");

        //    contact.Name = name;
        //    contact.Address = address;
        //    contact.Email = email;
        //    contact.Phone = phone;
        //    //contact.Names.Add(name);
        //    //contact.Addresses.Add(address);
        //    //contact.Emails.Add(email);
        //    //contact.Phones.Add(phone);
        //    customer.Contact = contact;
        //    Customers.Add(customer);
        //}
        //public void GenerateGlen()
        //{
        //    CustomerViewModel customer = new CustomerViewModel(this, new CustomerModel());
        //    ContactViewModel contact = new ContactViewModel(customer, new ContactModel());
        //    NameViewModel name = new NameViewModel(contact, "Glen Johnston");
        //    AddressViewModel address = new AddressViewModel(contact, "58 Oak St, Smithtown NY, 11787");
        //    EmailViewModel email = new EmailViewModel(contact, "freedomoil@optonline.net");
        //    PhoneViewModel phone = new PhoneViewModel(contact, "631-265-2002");

        //    contact.Name = name;
        //    contact.Address = address;
        //    contact.Email = email;
        //    contact.Phone = phone;
        //    //contact.Names.Add(name);
        //    //contact.Addresses.Add(address);
        //    //contact.Emails.Add(email);
        //    //contact.Phones.Add(phone);
        //    customer.Contact = contact;
        //    Customers.Add(customer);
        //}
        //public void GenerateKaeleigh()
        //{
        //    CustomerViewModel customer = new CustomerViewModel(this, new CustomerModel());
        //    ContactViewModel contact = new ContactViewModel(customer, new ContactModel());
        //    NameViewModel name = new NameViewModel(contact, "Kaeleigh Johnston");
        //    AddressViewModel address = new AddressViewModel(contact, "58 Oak St, Smithtown NY, 11787");
        //    EmailViewModel email = new EmailViewModel(contact, "freedomoil@optonline.net");
        //    PhoneViewModel phone = new PhoneViewModel(contact, "631-265-2002");

        //    contact.Name = name;
        //    contact.Address = address;
        //    contact.Email = email;
        //    contact.Phone = phone;
        //    //contact.Names.Add(name);
        //    //contact.Addresses.Add(address);
        //    //contact.Emails.Add(email);
        //    //contact.Phones.Add(phone);
        //    customer.Contact = contact;
        //    Customers.Add(customer);
        //}
        //public void GenerateNelson()
        //{
        //    CustomerViewModel customer = new CustomerViewModel(this, new CustomerModel());
        //    ContactViewModel contact = new ContactViewModel(customer, new ContactModel());
        //    NameViewModel name = new NameViewModel(contact, "Nelson Gomez");
        //    AddressViewModel address = new AddressViewModel(contact, "58 Oak St, Smithtown NY, 11787");
        //    EmailViewModel email = new EmailViewModel(contact, "freedomoil@optonline.net");
        //    PhoneViewModel phone = new PhoneViewModel(contact, "631-265-2002");

        //    contact.Name = name;
        //    contact.Address = address;
        //    contact.Email = email;
        //    contact.Phone = phone;
        //    //contact.Names.Add(name);
        //    //contact.Addresses.Add(address);
        //    //contact.Emails.Add(email);
        //    //contact.Phones.Add(phone);
        //    customer.Contact = contact;
        //    Customers.Add(customer);
        //}
        #endregion
    }
}