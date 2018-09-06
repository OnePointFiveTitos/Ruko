using System;
using System.Runtime.CompilerServices;

namespace Ruko
{
    public class PhoneViewModel : InformationViewModel
    {
        private Phone model; 
        public Phone Model { get => model; }
        public Array PhoneTypes { get => App.PhoneTypes; }
        public PhoneTypes PhoneType
        {
            get => model.phoneType;
            set
            {
                if (model.phoneType != value)
                {
                    model.phoneType = value;
                    OnPropertyChanged();
                }
            }
        }
        public int CountryCode
        {
            get => model.countryCode;
            set
            {
                if (model.countryCode != value)
                {
                    model.countryCode = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public int AreaCode
        {
            get => model.areaCode;
            set
            {
                if (model.areaCode != value)
                {
                    model.areaCode = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public int Prefix
        {
            get => model.prefix;
            set
            {
                if (model.prefix != value)
                {
                    model.prefix = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public int LineNumber
        {
            get => model.lineNumber;
            set
            {
                if (model.lineNumber != value)
                {
                    model.lineNumber = value;
                    //OnPropertyChanged();
                    OnChanged();
                }
            }
        }
        public string Phone
        {
            get => string.Format($"{CountryCode}-{AreaCode}-{Prefix}-{LineNumber}");
        }
        public PhoneViewModel(Phone model = null)
        {
            this.model = model ?? new Phone();
        }
        void OnChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(propertyName);
            OnPropertyChanged("Phone");
        }
    }
}