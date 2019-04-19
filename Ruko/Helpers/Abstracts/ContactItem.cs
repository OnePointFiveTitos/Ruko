using Xne_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public abstract class ContactItem<TModel> : SectionItemBase<Contact, TModel>, IContactItem where TModel : ContactItemModel
    {
        public virtual ContactTypes ContactType => GetType().Name.TryEnumParse<ContactTypes>();
        public bool IsPrimary
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
        public ContactItem(Contact parent, TModel model) : base(parent, model)
        {
        }
    }
    public abstract class ContactItemModel : SectionItemBaseModel
    {
        internal bool isPrimary;
    }
}