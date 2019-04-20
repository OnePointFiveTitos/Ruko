using Xne_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Ruko
{
    public abstract class ContactItem<TModel> : SectionItemBase<ContactProfile, TModel>, IContactItem where TModel : ContactItemModel
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
    }
    public abstract class ContactItemModel : SectionItemBaseModel
    {
        internal bool isPrimary;
        internal string input;
    }
}