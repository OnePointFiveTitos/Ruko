using System;
using System.Runtime.CompilerServices;

namespace Ruko
{
    public class AddressViewModel : InformationViewModel
    {
        private Address model;
        public Address Model { get => model; }
        public Array AddressTypes { get => App.AddressTypes; }
        public Array StateTypes { get => App.StateTypes; }
        public Array StateAbbreviationTypes { get => App.StateAbbreviationTypes; }
        public AddressTypes AddressType
        {
            get => model.addressType;
            set
            {
                if (model.addressType != value)
                {
                    model.addressType = value;
                    OnPropertyChanged(); //not used in the display string so dont need OnChanged();
                    //OnChanged();
                }
            }
        }
        public int AddressNumber
        {
            get => model.addressNumber;
            set
            {
                if (model.addressNumber != value)
                {
                    model.addressNumber = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string AddressLine
        {
            get => model.addressLine;
            set
            {
                if (model.addressLine != value)
                {
                    model.addressLine = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public int OptionalNumber
        {
            get => model.optionalNumber;
            set
            {
                if (model.optionalNumber != value)
                {
                    model.optionalNumber = value;
                    OnPropertyChanged();
                    //OnChanged(); //not used in the display string so dont need OnChanged();
                }
            }
        }
        public string City
        {
            get => model.city;
            set
            {
                if (model.city != value)
                {
                    model.city = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public StateTypes StateType
        {
            get => model.stateType;
            set
            {
                if (model.stateType != value)
                {
                    model.stateType = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string Zip_Code
        {
            get => model.zip_code;
            set
            {
                if (model.zip_code != value)
                {
                    model.zip_code = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string Address
        {
            get => string.Format($"{AddressNumber} {AddressLine}, {City} {StateType}, {Zip_Code} ");
        }
        public AddressViewModel(Address model = null)
        {
            this.model = model ?? new Address();
        }
        void OnChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged("Address");
        }
    }
}