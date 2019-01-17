using static Utilities.Regexes;
using static Utilities.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using System.Text.RegularExpressions;
using Enums;

namespace Ruko
{
    public class EmailViewModel : ContactInfoViewModel<EmailModel>, IContactMethod
    {
        #region Static Property Mapping
        public static List<string> PropertyMapping { get; }
        static EmailViewModel()
        {
            EmailViewModel sample;
            PropertyMapping = new List<string>()
            {
                nameof(sample.Handle),
                nameof(sample.Domain),
                nameof(sample.Register)
            };
        }
        #endregion
        public override int[] Indices => EmailIndices;
        public override Regex Regex => EmailEx;
        public override List<string> Mapping => PropertyMapping;
        public override string ConcatFull => $"{Handle}@{Domain}.{Register}";

        public string Handle
        {
            get => Model.handle;
            set
            {
                if (Model.handle != value)
                {
                    Model.handle = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string Domain
        {
            get => Model.domain;
            set
            {
                if (Model.domain != value)
                {
                    Model.domain = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ConcatFull));
                }
            }
        }
        public string Register
        {
            get => Model.register;
            set
            {
                if (Model.register != value)
                {
                    Model.register = value;
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

        public EmailViewModel(ContactViewModel parent, EmailModel model) : base(parent, model)
        {
            UseConcatFull = false;
        }
    }
}