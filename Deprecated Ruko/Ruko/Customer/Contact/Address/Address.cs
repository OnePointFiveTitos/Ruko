using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Functions;
using static Utilities.Regexes;
using Enums;
using MVVM;
using Managers;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Ruko
{
    public class AddressViewModel : ContactItemViewModel<AddressModel>, IAssociated
    {
        public NameViewModel AssociatedName
        {
            get => Model.associatedName;
            set
            {
                if (Model.associatedName != value)
                {
                    Model.associatedName = value;
                    OnPropertyChanged();
                }
            }
        }

        public override string Full => $"{Number} {Street}, {City} {State}, {string.Format("{0}", Extension != null ? $"{Zipcode}-{Extension}" : $"{Zipcode}")}";

        public int Number
        {
            get => Model.number;
            set
            {
                if (Model.number != value)
                {
                    Model.number = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Full));
                }
            }
        }
        public string Street
        {
            get => Model.street;
            set
            {
                if (Model.street != value)
                {
                    Model.street = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Full));
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
                    OnPropertyChanged(nameof(Full));
                }
            }
        }
        public StateCodes State
        {
            get => Model.state;
            set
            {
                if (Model.state != value)
                {
                    Model.state = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Full));
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
                    OnPropertyChanged(nameof(Full));
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
                    OnPropertyChanged(nameof(Full));
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

        public AddressViewModel(ContactViewModel parent, AddressModel model = null, NameViewModel associatedName = null) : base(parent, model)
        {
            Model = Model ?? new AddressModel();
            AssociatedName = associatedName;
        }
    }

    public class AddressModel : ContactItemModel
    {
        internal NameViewModel associatedName;
        internal int number;
        internal string street;
        internal string city;
        internal StateCodes state;
        internal int zipcode;
        internal int? extension;
        internal string crossStreet;
        public AddressModel()
        {

        }
        public AddressModel(int number, string street, string city, StateCodes state, int zipcode, int? extension, string crossStreet)
        {
            this.number = number;
            this.street = street;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
            this.extension = extension;
            this.crossStreet = crossStreet;
        }
    }
}