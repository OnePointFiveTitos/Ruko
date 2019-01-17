using static Utilities.Regexes;
using static Utilities.Functions;
using MVVM;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Enums;

namespace Ruko
{
    public class EmailViewModel : InformationViewModel<ContactViewModel, EmailModel>
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
        public EmailTypes Type
        {
            get => Model.type;
            set
            {
                if (Model.type != value)
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
        public string Handle { get; private set; }
        public string Domain { get; private set; }
        public string Register { get; private set; }
        public EmailViewModel(ContactViewModel parent, EmailModel model)
            : base(parent, model)
        {
        }
    }
}