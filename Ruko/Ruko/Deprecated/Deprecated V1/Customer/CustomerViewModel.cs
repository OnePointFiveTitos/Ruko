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
    public class CustomerViewModel : NodeViewModel<RukoViewModel, CustomerModel>
    {
        public NameViewModel Name => Contact.Name;
        public AddressViewModel Address => Contact.Address;
        public EmailViewModel Email => Contact.Email;
        public PhoneViewModel Phone => Contact.Phone;
        public ContactViewModel Contact
        {
            get => Model.contact;
            set
            {
                if (Model.contact != value)
                {
                    Model.contact = value;
                    OnPropertiesChanged(this);
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
        public int SelectedViewTabIndex
        {
            get => Model.selectedViewTabIndex;
            set
            {
                if (Model.selectedViewTabIndex != value)
                {
                    Model.selectedViewTabIndex = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ModificationButtonTest => IsModifying ? "Apply" : "Modify";
        public bool IsModifying
        {
            get => Model.isModifying;
            set
            {
                if (Model.isModifying != value)
                {
                    Model.isModifying = value;
                    SelectedViewTabIndex = 1;
                    OnPropertiesChanged(this);
                }
            }
        }
        public bool IsOpened
        {
            get => Model.IsOpened;
            set
            {
                if (Model.IsOpened != value)
                {
                    Model.IsOpened = value;
                    OnPropertiesChanged(this);
                }
            }
        }
        public ICommand ModifyCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }
        public CustomerViewModel(RukoViewModel parent, CustomerModel model) 
            : base(parent, model)
        {
            //Contact = new ContactViewModel(this, Model.contact);
            //Service = new ServiceViewModel(this, Model.service);

            //Name = new NameViewModel(Contact, Contact.Names.Primary);
            //Address = new AddressViewModel(Contact, Contact.Addresses.Primary);
            //Email = new EmailViewModel(Contact, Contact.Emails.Primary);
            //Phone = new PhoneViewModel(Contact, Contact.Phones.Primary);
        }

        public override void InitializeCommands()
        {
            ModifyCommand = new RelayCommand(() =>
            {
                if (IsModifying)
                {
                    IsModifying = MessageBox.Show("Confirm Changes?", "Apply changes", MessageBoxButton.OKCancel) != MessageBoxResult.OK; //if ok then false (ie apply changes) else cancel (true)- maintain modification state
                }
                else
                {
                    IsModifying = true;
                }

                //IsModifying = !IsModifying;
            });
            CancelCommand = new RelayCommand(() =>
            {
                if (IsModifying)
                {
                    IsModifying = MessageBox.Show("Cancel Changes?", "Revert changes", MessageBoxButton.OKCancel) != MessageBoxResult.OK; //if ok then false (ie apply changes) else cancel (true)- maintain modification state
                }
                else
                {
                    IsModifying = true;
                }
                //IsModifying = false;
            });
            CloseCommand = new RelayCommand(() =>
            {
                IsModifying = false;
                //Parent.SelectedOpenedCustomer = Parent.OpenedCustomers.ElementAt(Parent.OpenedCustomers.IndexOf(this) - 1); //out of range
                Parent.OpenedCustomers.Remove(this);
                Parent.SelectedOpenedCustomer = Parent.OpenedCustomers.FirstOrDefault();
            });
        }
    }
}