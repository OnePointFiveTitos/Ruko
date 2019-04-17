using System.Collections.ObjectModel;
namespace Ruko
{
    public class ContactViewModel : InfoViewModel<ContactModel>
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

        public ContactViewModel(CustomerViewModel parent, ContactModel model) : base(parent, model, "Contact")
        {
            //Model = Model ?? new ContactModel(new NameViewModel(this), new AddressViewModel(this), new EmailViewModel(this), new PhoneViewModel(this));
        }

        public void ToggleItemPersistence(ContactItemTypes itemType, ContactItemViewModel<ContactItemModel> item, bool isAdded)
        {

        }

        public void SwapPrimaryItem(ContactItemTypes itemType, ContactItemViewModel<ContactItemModel> item)
        {

        }
    }

    public class ContactModel : InfoModel
    {
        internal NameViewModel name;
        internal AddressViewModel address;
        internal EmailViewModel email;
        internal PhoneViewModel phone;
        public ContactModel()
        {

        }
        public ContactModel(NameViewModel name, AddressViewModel address, EmailViewModel email, PhoneViewModel phone)
        {
            this.name = name;
            this.address = address;
            this.email = email;
            this.phone = phone;
        }
    }
}