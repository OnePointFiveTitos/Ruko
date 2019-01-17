using static Utilities.Regexes;
using static Utilities.Functions;
using MVVM;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Enums;

namespace Ruko
{
    public class PhoneViewModel : InformationViewModel<ContactViewModel,PhoneModel>
    {
        #region Static Property Mapping
        public static List<string> PropertyMapping { get; }
        static PhoneViewModel()
        {
            PhoneViewModel sample;
            //Country code and extension are values that are added separately
            PropertyMapping = new List<string>()
            {
                nameof(sample.Areacode),
                nameof(sample.Prefix),
                nameof(sample.Line),
            };
        }
        #endregion
        public override int[] Indices => PhoneIndices;
        public override Regex Regex => PhoneEx;
        public override List<string> Mapping => PropertyMapping;
        public PhoneTypes Type
        {
            get => Model.type;
            set
            {
                if (Model.type!=value)
                {
                    Model.type = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsPreferred
        {
            get => Model.isPreferred;
            set
            {
                if (Model.isPreferred != value)
                {
                    Model.isPreferred = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Country { get; private set; }
        public string Areacode { get; private set; }
        public string Prefix { get; private set; }
        public string Line { get; private set; }
        public string Extension { get; private set; }
        public PhoneViewModel(ContactViewModel parent, PhoneModel model)
            : base(parent, model)
        {
        }
    }
}