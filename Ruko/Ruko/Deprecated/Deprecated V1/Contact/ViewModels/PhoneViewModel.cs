using ControlsAndResources;
using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using static Utilities.Functions;
using static Utilities.Regexes;

namespace Ruko
{
    public class PhoneViewModel : AssociationViewModel<ContactViewModel, PhoneModel>, IDynamicObject
    {
        #region DynamicObject
        public static Dictionary<string, string> Mapping { get; }
        static PhoneViewModel()
        {
            PhoneViewModel sample = new PhoneViewModel(null, null);
            Mapping = new Dictionary<string, string>()
            {
                [nameof(sample.AreaCode)] = "AreaCode: ",
                [nameof(sample.Prefix)] = "Prefix: ",
                [nameof(sample.LineNumber)] = "LineNumber: ",
                [nameof(sample.CountryCode)] = "CountryCode: ",
                [nameof(sample.Extension)] = "Extension: ",
            };
        }
        #endregion
        public string Phone
        {
            get => Model.phone;
            set
            {
                if (Model.phone != value)
                {
                    Model.phone = value;
                    EvaluatePhone();
                    OnPropertiesChanged(this);
                }
            }
        }
        public string AreaCode { get; private set; }
        public string Prefix { get; private set; }
        public string LineNumber { get; private set; }
        public int? CountryCode
        {
            get => Model.countryCode;
            set
            {
                if (Model.countryCode != value)
                {
                    Model.countryCode = value;
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
        public override string Full => Phone;
        public override Dictionary<string, string> PropertiesMapping => Mapping;
        public PhoneViewModel(ContactViewModel parent, PhoneModel model)
            : base(parent, model)
        {
        }
        void EvaluatePhone()
        {
            GroupCollection groups = PhoneEx.Match(Phone).Groups;
            AreaCode = groups[1].Value;
            Prefix = groups[2].Value;
            LineNumber = groups[3].Value;
        }
    }
}