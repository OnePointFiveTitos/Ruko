using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace Ruko
{
    public abstract class SubInfoViewModel<TParent, TModel> : NodeViewModel<TParent, TModel>
        where TParent : IViewModel
        where TModel : SubInfoModel
    {
        public bool IsValid
        {
            get => Model.isValid;
            set
            {
                if (Model.isValid != value)
                {
                    Model.isValid = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsRequired
        {
            get => Model.isRequired;
            set
            {
                if (Model.isRequired != value)
                {
                    Model.isRequired = value;
                    OnPropertyChanged();
                }
            }
        }
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

        public SubInfoViewModel(TParent parent, TModel model) : base(parent, model)
        {
        }
    }
}