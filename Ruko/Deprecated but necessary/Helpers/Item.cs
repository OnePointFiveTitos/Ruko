using MVVM;
namespace Ruko
{
    public abstract class ItemViewModel<TParent, TModel> : NodeViewModel<TParent, TModel>
        where TParent : IViewModel
        where TModel : ItemModel
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

        public ItemViewModel(TParent parent, TModel model) : base(parent, model)
        {
        }
    }

    public abstract class ItemModel
    {
        internal bool isValid;
        internal bool isRequired;
        internal bool isPrimary;
    }
}