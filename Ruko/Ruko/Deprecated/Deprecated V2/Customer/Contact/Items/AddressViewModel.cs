using static Utilities.Regexes;
using static Utilities.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using System.Text.RegularExpressions;

namespace Ruko
{
    public class AddressViewModel : ContactInfoViewModel<AddressModel>
    {
        #region Static Property Mapping
        public static List<string> PropertyMapping { get; }
        static AddressViewModel()
        {
            AddressViewModel sample;
            PropertyMapping = new List<string>()
            {
                nameof(sample.Street),
                nameof(sample.City),
                nameof(sample.State),
                nameof(sample.FullZipcode),
                nameof(sample.Zipcode),
                nameof(sample.Extension)
            };
        }
        #endregion
        public override int[] Indices => AddressIndices;
        public override Regex Regex => AddressEx;
        public override List<string> Mapping => PropertyMapping;
        public override string ConcatFull => $"{Street}, {City} {State}, {FullZipcode}";
        public string Street
        {
            get => Model.street;
            set
            {
                if (Model.street != value)
                {
                    Model.street = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
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
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string State
        {
            get => Model.state;
            set
            {
                if (Model.state != value)
                {
                    Model.state = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string FullZipcode
        {
            get => Model.fullZipcode;
            set
            {
                if (Model.fullZipcode != value)
                {
                    Model.fullZipcode = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string Zipcode
        {
            get => Model.zipcode;
            set
            {
                if (Model.zipcode != value)
                {
                    Model.zipcode = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string Extension
        {
            get => Model.extension;
            set
            {
                if (Model.extension != value)
                {
                    Model.extension = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
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
                    OnPropertyChanged(nameof(Parent.Parent.Oil.CrossStreet));
                }
            }
        }
        public AddressViewModel(ContactViewModel parent, AddressModel model) : base(parent, model)
        {
            UseConcatFull = false;
        }
    }
}