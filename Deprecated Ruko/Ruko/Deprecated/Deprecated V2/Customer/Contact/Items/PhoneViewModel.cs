using static Utilities.Regexes;
using static Utilities.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MVVM;
using Enums;

namespace Ruko
{
    public class PhoneViewModel : ContactInfoViewModel<PhoneModel>, IContactMethod
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
        public override string ConcatFull => $"{Areacode}-{Prefix}-{Line}";
        public string Country
        {
            get => Model.country;
            set
            {
                if (Model.country != value)
                {
                    Model.country = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string Areacode
        {
            get => Model.areacode;
            set
            {
                if (Model.areacode != value)
                {
                    Model.areacode = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string Prefix
        {
            get => Model.prefix;
            set
            {
                if (Model.prefix != value)
                {
                    Model.prefix = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string Line
        {
            get => Model.line;
            set
            {
                if (Model.line != value)
                {
                    Model.line = value;
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

        private bool isPreferred;
        public bool IsPreferred
        {
            get => isPreferred;
            set
            {
                if (isPreferred != value)
                {
                    isPreferred = value;
                    OnPropertyChanged();
                }
            }
        }
        private ContactTypes type;
        public ContactTypes Type
        {
            get => type;
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged();
                }
            }
        }

        public PhoneViewModel(ContactViewModel parent, PhoneModel model) : base(parent, model)
        {
            UseConcatFull = false;
        }
    }
}