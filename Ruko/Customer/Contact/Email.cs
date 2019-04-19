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
        public Email(Contact parent, EmailModel model) : base(parent, model)
        {
        }
    }

    public class EmailModel : ContactItemModel
    {
        internal string handle;
        internal string domain;
        internal string register;
    }
}