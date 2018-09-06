namespace Ruko
{
    public class InformationViewModel : ObservableObject
    {
        private Information model;

        public Name AssociatedName
        {
            get => model.associatedName;
            set
            {
                if (model.associatedName!=value)
                {
                    model.associatedName = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsPrimary
        {
            get => model.isPrimary;
            set
            {
                if (model.isPrimary != value)
                {
                    model.isPrimary = value;
                    OnPropertyChanged();
                }
            }
        }

        public InformationViewModel(Information model = null)
        {
            this.model = model ?? new Information();
        }
    }
}