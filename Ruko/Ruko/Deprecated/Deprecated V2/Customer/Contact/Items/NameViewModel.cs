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
    public class NameViewModel : ContactInfoViewModel<NameModel>
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
        public override string ConcatFull => $"{First} {Last}";
        public string Initials => $"{First[0]}{Last[0]}";
        public string First
        {
            get => Model.first;
            set
            {
                if (Model.first != value)
                {
                    Model.first = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string Middle
        {
            get => Model.middle;
            set
            {
                if (Model.middle != value)
                {
                    Model.middle = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string Last
        {
            get => Model.last;
            set
            {
                if (Model.last != value)
                {
                    Model.last = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }

        public NameViewModel(ContactViewModel parent, NameModel model) : base(parent, model)
        {
            UseConcatFull = false;
        }
    }
}