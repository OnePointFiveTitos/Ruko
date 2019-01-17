using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ruko
{
    public class AddCustomerViewModel : NodeViewModel<RukoViewModel, AddCustomerModel>
    {
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
        public ContactViewModel Contact
        {
            get => Model.contact;
            set
            {
                if (Model.contact != value)
                {
                    Model.contact = value;
                    OnPropertyChanged();
                }
            }
        }
        public ServiceViewModel Service
        {
            get => Model.service;
            set
            {
                if (Model.service != value)
                {
                    Model.service = value;
                    OnPropertyChanged();
                }
            }
        }
        public NameViewModel Name
        {
            get => Model.name;
            set
            {
                if (Model.name != value)
                {
                    Model.name = value;
                    OnPropertyChanged();
                }
            }
        }
        public AddressViewModel Address
        {
            get => Model.address;
            set
            {
                if (Model.address != value)
                {
                    Model.address = value;
                    OnPropertyChanged();
                }
            }
        }
        public AddressViewModel AdditionalAddress
        {
            get => Model.additionalAddress;
            set
            {
                if (Model.additionalAddress!=value)
                {
                    Model.additionalAddress = value;
                    OnPropertyChanged();
                }
            }
        }
        public PhoneViewModel Phone
        {
            get => Model.phone;
            set
            {
                if (Model.phone != value)
                {
                    Model.phone = value;
                    OnPropertyChanged();
                }
            }
        }
        public EmailViewModel Email
        {
            get => Model.email;
            set
            {
                if (Model.email != value)
                {
                    Model.email = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand CreateCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public AddCustomerViewModel(RukoViewModel parent, AddCustomerModel model) 
            : base(parent, model)
        {
            Reset();
        }

        void Reset()
        {
            Customer = new CustomerViewModel(Parent, new CustomerModel());
            Contact = new ContactViewModel(Customer, new ContactModel());
            Service = new ServiceViewModel(Customer, new ServiceModel());
            Name = new NameViewModel(Contact, new NameModel(null));
            Address = new AddressViewModel(Contact, new AddressModel(null));
            Phone = new PhoneViewModel(Contact, new PhoneModel(null));
            Email = new EmailViewModel(Contact, new EmailModel(null));
        }

        void Set()
        {
            Contact.Name = Name;
            Contact.Address = Address;
            Contact.Email = Email;
            Contact.Phone = Phone;
            //Contact.Names.Add(Name);
            //Contact.Addresses.Add(Address);
            //Contact.Emails.Add(Email);
            //Contact.Phones.Add(Phone);
            Customer.Contact = Contact;
            Customer.Service = Service;
        }

        public override void InitializeCommands()
        {
            CreateCommand = new RelayCommand(() =>
            {
                Set();
                Parent.Customers.Add(Customer);
                Parent.IsAddingCustomer = false;
            });

            ResetCommand = new RelayCommand(() => Reset());

            CancelCommand = new RelayCommand(() =>
            {
                Set();
                Customer = null;
                Parent.IsAddingCustomer = false;
            });
        }
    }
}