using Enums;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ruko
{
    public class ContactViewModel : NodeViewModel<CustomerViewModel, ContactModel>
    {
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

        public ObservableCollection<NameViewModel> Names { get; } = new ObservableCollection<NameViewModel>();
        public ObservableCollection<AddressViewModel> Addresses { get; } = new ObservableCollection<AddressViewModel>();
        public ObservableCollection<EmailViewModel> Emails { get; } = new ObservableCollection<EmailViewModel>();
        public ObservableCollection<PhoneViewModel> Phones { get; } = new ObservableCollection<PhoneViewModel>();

        public PreferredContactTypes PreferredContactType
        {
            get => Model.preferredContactType;
            set
            {
                if (Model.preferredContactType != value)
                {
                    Model.preferredContactType = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsSameBillAndMailTo
        {
            get => Model.isSameBillAndMailTo;
            set
            {
                if (Model.isSameBillAndMailTo != value)
                {
                    Model.isSameBillAndMailTo = value;
                    OnPropertyChanged();
                }
            }
        }

        //public Name Name => Names.Primary;
        //public Address Address => Addresses.Primary;
        //public Email Email => Emails.Primary;
        //public Phone Phone => Phones.Primary;

        //public PrimaryAssociatedPair<Name> Names { get; }
        //public PrimaryAssociatedPair<Address> Addresses { get; }
        //public PrimaryAssociatedPair<Email> Emails { get; }
        //public PrimaryAssociatedPair<Phone> Phones { get; }

        public ContactViewModel(CustomerViewModel parent, ContactModel model)
            : base(parent, model)
        {
            //Names = new PrimaryAssociatedPair<Name>(Model.name);
            //Addresses = new PrimaryAssociatedPair<Address>(Model.address);
            //Emails = new PrimaryAssociatedPair<Email>(Model.email);
            //Phones = new PrimaryAssociatedPair<Phone>(Model.phone);
        }
    }
}