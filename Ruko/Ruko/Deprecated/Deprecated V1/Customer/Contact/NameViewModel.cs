using MVVM;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static Utilities.Regexes;

namespace Ruko
{
    public class NameViewModel : InformationViewModel<ContactViewModel, NameModel>
    {
        #region Static Property Mapping
        public static List<string> PropertyMapping { get; }
        static NameViewModel()
        {
            NameViewModel sample;
            PropertyMapping = new List<string>()
            {
                nameof(sample.First),
                nameof(sample.Middle),
                nameof(sample.Last)
            };
        }
        #endregion
        public override int[] Indices => NameIndices;
        public override Regex Regex => NameEx;
        public override List<string> Mapping => PropertyMapping;
        public string First { get; private set; }
        public string Middle { get; private set; }
        public string Last { get; private set; }
        public NameViewModel(ContactViewModel parent, NameModel model)
            : base(parent, model)
        {
        }
    }
}