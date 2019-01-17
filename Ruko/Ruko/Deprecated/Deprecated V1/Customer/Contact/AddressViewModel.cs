using static Utilities.Regexes;
using static Utilities.Functions;
using MVVM;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Ruko
{
    public class AddressViewModel : InformationViewModel<ContactViewModel, AddressModel>
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
        //public bool IsSameBillAndMailTo
        //{
        //    get => Model.isSameBillAndMailTo;
        //    set
        //    {
        //        if (Model.isSameBillAndMailTo != value)
        //        {
        //            Model.isSameBillAndMailTo = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string FullZipcode { get; private set; }
        public string Zipcode { get; private set; }
        public string Extension { get; private set; }
        public AddressViewModel(ContactViewModel parent, AddressModel model)
            : base(parent, model)
        {
        }
    }
}