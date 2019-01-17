using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public abstract class AssociationViewModel<TParentViewModel, TModel> : InformationViewModel<TParentViewModel, TModel>, IAssociation
        where TModel : AssociationModel
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
        public AssociationViewModel(TParentViewModel parent, TModel model) : base(parent, model)
        {
        }
        public virtual void Associate(NameViewModel name)
            => AssociatedName = name;
    }
}