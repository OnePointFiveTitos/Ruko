using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class ContactProfile : NodeViewModel<Contact, ContactProfileModel>
    {
        public Name Name => Model.name;
        public Address Address
        {
            get => Model.address;
            private set
            {
                if (Model.address != value)
                {
                    Model.address = value;
                    OnPropertyChanged();
                }
            }
        }
        public Email Email
        {
            get => Model.email;
            private set
            {
                if (Model.email != value)
                {
                    Model.email = value;
                    OnPropertyChanged();
                }
            }
        }
        public Phone Phone
        {
            get => Model.phone;
            private set
            {
                if (Model.phone != value)
                {
                    Model.phone = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Address> Addresses { get; } = new ObservableCollection<Address>();
        public ObservableCollection<Email> Emails { get; } = new ObservableCollection<Email>();
        public ObservableCollection<Phone> Phones { get; } = new ObservableCollection<Phone>();

        public ContactProfile(Contact parent, ContactProfileModel model) : base(parent, model)
        {
        }

        //public T GetPrimary<T>(IEnumerable<T> items) where T : IContactItem => items.FirstOrDefault(item => item.IsPrimary);
        //public void SetPrimary<T>(T primary) where T : IContactItem
        //{
        //    switch (primary.ContactType)
        //    {
        //        case ContactTypes.Name:
        //            break;
        //        case ContactTypes.Address:
        //            break;
        //        case ContactTypes.Email:
        //            break;
        //        case ContactTypes.Phone:
        //            break;
        //        default:
        //            throw new ArgumentException("Wrong ContactType type");
        //    }
        //}

        //void SwapPrimary<T>(T currentPrimary, T newPrimary) where T : IContactItem
        //{
        //    currentPrimary.IsPrimary = false;
        //    newPrimary.IsPrimary = true;
        //}
    }

    public class ContactProfileModel
    {
        internal Name name;
        internal Address address;
        internal Email email;
        internal Phone phone;

        public ContactProfileModel(Name name, Address address = null, Email email = null, Phone phone = null)
        {
            this.name = name;
            this.address = address;
            this.email = email;
            this.phone = phone;
        }
    }
}