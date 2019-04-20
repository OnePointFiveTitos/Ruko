using Xne_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Xne_MVVM;
using System.Windows.Input;

namespace Ruko
{
    public abstract class ContactItem<TModel> : SectionItemBase<ContactProfile, TModel>, IContactItem, ICommander where TModel : ContactItemModel
    {
        public abstract Regex ValidationExpression { get; }
        public virtual ContactTypes ContactType => GetType().Name.TryEnumParse<ContactTypes>();
        public virtual bool IsPrimary
        {
            get => Model.isPrimary;
            set
            {
                if (Model.isPrimary != value)
                {
                    Model.isPrimary = value;
                    OnPropertyChanged();
                }
            }
        }
        public virtual string Input
        {
            get => Model.input;
            set
            {
                if (Model.input != value)
                {
                    Model.input = value;
                    OnPropertyChanged();
                    Validate();
                }
            }
        }

        #region Commands
        public virtual Dictionary<string, ICommand> Commands { get; private set; }
        public ICommand SetAsPrimaryCommand => Commands["SetAsPrimary"];
        #endregion

        public event EventHandler<Match> Validated;
        public ContactItem(ContactProfile parent, TModel model) : base(parent, model)
        {
            Validated += (sender, e) => OnValidated(e.Groups.OfType<Group>().Select(group => group.Value));
        }

        public virtual void Validate()
        {
            Match validationMatch = null;
            if (ContactType != ContactTypes.Address)
            {
                validationMatch = Input.Match(ValidationExpression);
                if (validationMatch.Success)
                {
                    Validated?.Invoke(this, validationMatch);
                }
            }
        }

        public abstract void OnValidated(IEnumerable<string> values);

        public virtual void SetAsPrimary()
        {
            if (ContactType != ContactTypes.Name)
            {
                Parent.SetPrimary(this);
            }
            else
            {
                Parent.Parent.Primary = Parent;
            }
        }

        public virtual void InitializeCommands()
        {
            Commands = new Dictionary<string, ICommand>
            {
                ["SetAsPrimary"] = new RelayCommand(SetAsPrimary),
            };
        }
    }
    public abstract class ContactItemModel : SectionItemBaseModel
    {
        internal bool isPrimary;
        internal string input;
    }
}