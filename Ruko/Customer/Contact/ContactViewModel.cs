using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Ruko
{
    public class ContactViewModel : InformationViewModel
    {
        private Contact model;
        //display values when view-only
        public NameViewModel PrimaryName
        {
            get => new NameViewModel(model.primaryName);
            set
            {
                if (model.primaryName != value.Model)
                {
                    model.primaryName = value.Model;
                    OnPropertyChanged();
                }
            }
        }
        public AddressViewModel PrimaryAddress
        {
            get => new AddressViewModel(model.primaryAddress);
            set
            {
                if (model.primaryAddress != value.Model)
                {
                    model.primaryAddress = value.Model;
                    OnPropertyChanged();
                }
            }
        }
        public EmailViewModel PrimaryEmail
        {
            get => new EmailViewModel(model.primaryEmail);
            set
            {
                if (model.primaryEmail != value.Model)
                {
                    model.primaryEmail = value.Model;
                    OnPropertyChanged();
                }
            }
        }
        public PhoneViewModel PrimaryPhone
        {
            get => new PhoneViewModel(model.primaryPhone);
            set
            {
                if (model.primaryPhone != value.Model)
                {
                    model.primaryPhone = value.Model;
                    OnPropertyChanged();
                }
            }
        }
        //lists viewable when in edit mode
        public ObservableCollection<NameViewModel> Names
        {
            get => model.names.Select(name => new NameViewModel(name)) as ObservableCollection<NameViewModel>;
            set
            {
                if (model.names != value)
                {
                    model.names = value.Select(nameVM => nameVM.Model);
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<AddressViewModel> Addresses
        {
            get => model.addresses.Select(address => new AddressViewModel(address)) as ObservableCollection<AddressViewModel>;
            set
            {
                if (model.addresses != value)
                {
                    model.addresses = value.Select(addressVM => addressVM.Model);
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<EmailViewModel> Emails
        {
            get => model.emails.Select(email => new EmailViewModel(email)) as ObservableCollection<EmailViewModel>;
            set
            {
                if (model.emails != value)
                {
                    model.emails = value.Select(emailVM => emailVM.Model);
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<PhoneViewModel> Phones
        {
            get => model.phones.Select(phone => new PhoneViewModel(phone)) as ObservableCollection<PhoneViewModel>;
            set
            {
                if (model.phones != value)
                {
                    model.phones = value.Select(phoneVM => phoneVM.Model);
                    OnPropertyChanged();
                }
            }
        }
        public ContactViewModel(Contact model = null)
        {
            this.model = model ?? new Contact();
        }
    }
}