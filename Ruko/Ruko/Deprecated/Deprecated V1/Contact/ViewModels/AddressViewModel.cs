using ControlsAndResources;
using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using static Utilities.Functions;

namespace Ruko
{
    public class AddressViewModel : AssociationViewModel<ContactViewModel, AddressModel>, IDynamicObject
    {
        #region DynamicObject
        public static Dictionary<string, string> Mapping { get; }
        static AddressViewModel()
        {
            AddressViewModel sample = new AddressViewModel(null, null);
            Mapping = new Dictionary<string, string>()
            {
                [nameof(sample.Street)] = "Street: ",
                [nameof(sample.City)] = "City: ",
                [nameof(sample.State)] = "State: ",
                [nameof(sample.ZipCode)] = "ZipCode: ",
                [nameof(sample.ZipCodeExtension)] = "ZipCodeExtension: ",
            };
        }
        #endregion
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
        public string State
        {
            get => Model.state;
            set
            {
                if (Model.state != value)
                {
                    Model.state = value;
                    OnPropertyChanged();
                }
            }
        }
        public int ZipCode
        {
            get => Model.zipCode;
            set
            {
                if (Model.zipCode != value)
                {
                    Model.zipCode = value;
                    OnPropertyChanged();
                }
            }
        }
        public int? ZipCodeExtension
        {
            get => Model.zipCodeExtension;
            set
            {
                if (Model.zipCodeExtension != value)
                {
                    Model.zipCodeExtension = value;
                    OnPropertyChanged();
                }
            }
        }
        public override string Full => $"{Street}, {City}, {State} {ZipCode}";
        public override Dictionary<string, string> PropertiesMapping => Mapping;
        public AddressViewModel(ContactViewModel parent, AddressModel model) 
            : base(parent, model)
        {
        }
    }
}