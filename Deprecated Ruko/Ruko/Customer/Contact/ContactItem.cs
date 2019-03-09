using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ruko
{
    public abstract class ContactItemViewModel<TModel> : ItemViewModel<ContactViewModel, TModel>
        where TModel : ContactItemModel
    {
        //public abstract Regex ParseFullRegex { get; }
        //public abstract int[] PropertyIndices { get; }
        //public abstract List<string> PropertyMapping { get; }

        //public string Full
        //{
        //    get => Model.full;
        //    set
        //    {
        //        if (Model.full != value)
        //        {
        //            Model.full = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}
        public abstract string Full { get; }

        public ContactItemViewModel(ContactViewModel parent, TModel model) : base(parent, model)
        {
        }

        public override string ToString() => Full;
    }

    public abstract class ContactItemModel : ItemModel
    {
        //internal string full;
    }
}