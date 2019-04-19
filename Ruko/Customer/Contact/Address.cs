using System.Text.RegularExpressions;
using Xne_MVVM;
using static Ruko.Regexes;

namespace Ruko
{
    public class Address : ContactItem<AddressModel>, IAddressItem
    {
        public string Street
        {
            get => Model.street;
            set
            {
                if (Model.street != value)
                {
                    Model.street = value;
                    OnPropertyChanged();
                }
            }
        }
        public string City
        {
            get => Model.city;
            set
            {
                if (Model.city != value)
                {
                    Model.city = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Zipcode
        {
            get => Model.zipcode;
            set
            {
                if (Model.zipcode != value)
                {
                    Model.zipcode = value;
                    OnPropertyChanged();
                }
            }
        }
        public int? Extension
        {
            get => Model.extension;
            set
            {
                if (Model.extension != value)
                {
                    Model.extension = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CrossStreet
        {
            get => Model.crossStreet;
            set
            {
                if (Model.crossStreet != value)
                {
                    Model.crossStreet = value;
                    OnPropertyChanged();
                }
            }
        }
        public Address(Contact parent, AddressModel model) : base(parent, model)
        {
        }
    }

    public class AddressModel : ContactItemModel
    {
        internal string street;
        internal string city;
        internal int zipcode;
        internal int? extension;
        internal string crossStreet;
    }
}