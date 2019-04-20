using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Contact : SectionBase<ContactModel>
    {
        public ContactProfile Primary
        {
            get => Model.primary;
            set
            {
                if (Model.primary != value)
                {
                    Model.primary.IsPrimary = false;
                    value.IsPrimary = true;
                    Model.primary = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<ContactProfile> Associated { get; } = new ObservableCollection<ContactProfile>();

        public Contact(Customer parent, ContactModel model) : base(parent, model)
        {
        }
    }

    public class ContactModel : SectionBaseModel
    {
        internal ContactProfile primary;
    }
}