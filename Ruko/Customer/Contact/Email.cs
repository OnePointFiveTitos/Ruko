using Xne_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xne_MVVM;
using static Ruko.Regexes;

namespace Ruko
{
    public class Email : ContactItem<EmailModel>, IEmailItem
    {
        public override Regex ValidationExpression => EmailValidationExpression;

        public string Handle
        {
            get => Model.handle;
            set
            {
                if (Model.handle != value)
                {
                    Model.handle = value;
                    OnPropertyChanged();
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
                }
            }
        }
        public Email(ContactProfile parent, EmailModel model) : base(parent, model)
        {

        }

        public override void OnValidated(IEnumerable<string> values)
        {
            Handle = values.At(1);
            Domain = values.At(2);
            Register = values.At(3);
        }
    }

    public class EmailModel : ContactItemModel
    {
        internal string handle;
        internal string domain;
        internal string register;
    }
}