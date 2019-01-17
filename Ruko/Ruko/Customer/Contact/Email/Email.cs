using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Functions;
using static Utilities.Regexes;
using Enums;
using MVVM;
using Managers;
using System.Windows.Input;
namespace Ruko
{
    public class EmailViewModel : ContactItemViewModel<EmailModel>, IContactMethod, IAssociated
    {
        public NameViewModel AssociatedName
        {
            get => Model.associatedName;
            set
            {
                if (Model.associatedName != value)
                {
                    Model.associatedName = value;
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
        public ContactTypes ContactType
        {
            get => Model.contactType;
            set
            {
                if (Model.contactType != value)
                {
                    Model.contactType = value;
                    OnPropertyChanged();
                }
            }
        }

        public override string Full => $"{Handle}@{Domain}.{Register}";

        public string Handle
        {
            get => Model.handle;
            set
            {
                if (Model.handle != value)
                {
                    Model.handle = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Full));
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
                    OnPropertyChanged(nameof(Full));
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
                    OnPropertyChanged(nameof(Full));
                }
            }
        }

        public EmailViewModel(ContactViewModel parent, EmailModel model = null, NameViewModel associatedName = null, bool isPreferred = true, ContactTypes contactType = ContactTypes.Personal) : base(parent, model)
        {
            Model = Model ?? new EmailModel();
            AssociatedName = associatedName;
            IsPreferred = IsPreferred;
            ContactType = contactType;
        }
    }

    public class EmailModel : ContactItemModel
    {
        internal NameViewModel associatedName;
        internal bool isPreferred;
        internal ContactTypes contactType;
        internal string handle;
        internal string domain;
        internal string register;
        public EmailModel()
        {

        }
        public EmailModel(string handle, string domain, string register)
        {
            this.handle = handle;
            this.domain = domain;
            this.register = register;
        }
    }
}