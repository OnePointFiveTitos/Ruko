using MVVM;
namespace Ruko
{
    public class SystemViewModel : NodeViewModel<ServiceViewModel, SystemModel>
    {
        public string BoilerMAke
        {
            get => Model.boilerMake;
            set
            {
                if (Model.boilerMake != value)
                {
                    Model.boilerMake = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserParameter PrimaryType
        {
            get => Model.primaryType;
            set
            {
                if (Model.primaryType != value)
                {
                    Model.primaryType = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserParameter SecondaryType
        {
            get => Model.secondaryType;
            set
            {
                if (Model.secondaryType != value)
                {
                    Model.secondaryType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string BurnerMake
        {
            get => Model.burnerMake;
            set
            {
                if (Model.burnerMake != value)
                {
                    Model.burnerMake = value;
                    OnPropertyChanged();
                }
            }
        }
        public string BurnerSize
        {
            get => Model.burnerSize;
            set
            {
                if (Model.burnerSize != value)
                {
                    Model.burnerSize = value;
                    OnPropertyChanged();
                }
            }
        }
        public string NozzleSize
        {
            get => Model.nozzleSize;
            set
            {
                if (Model.nozzleSize != value)
                {
                    Model.nozzleSize = value;
                    OnPropertyChanged();
                }
            }
        }
        public string FilterSize
        {
            get => Model.filterSize;
            set
            {
                if (Model.filterSize != value)
                {
                    Model.filterSize = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserParameter TransformerType
        {
            get => Model.transformerType;
            set
            {
                if (Model.transformerType != value)
                {
                    Model.transformerType = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserParameter CirculatorType
        {
            get => Model.circulatorType;
            set
            {
                if (Model.circulatorType != value)
                {
                    Model.circulatorType = value;
                    OnPropertyChanged();
                }
            }
        }

        public SystemViewModel(ServiceViewModel parent, SystemModel model = null) : base(parent, model)
        {
            Model = Model ?? new SystemModel();
        }
    }

    public class SystemModel
    {
        internal string boilerMake;
        internal UserParameter primaryType;
        internal UserParameter secondaryType;
        internal string burnerMake;
        internal string burnerSize;
        internal string nozzleSize;
        internal string filterSize;
        internal UserParameter transformerType;
        internal UserParameter circulatorType;
        public SystemModel()
        {

        }
        public SystemModel(string boilerMake, UserParameter primaryType, UserParameter secondaryType, string burnerMake, string burnerSize, string nozzleSize, string filterSize, UserParameter transformerType, UserParameter circulatorType)
        {
            this.boilerMake = boilerMake;
            this.primaryType = primaryType;
            this.secondaryType = secondaryType;
            this.burnerMake = burnerMake;
            this.burnerSize = burnerSize;
            this.nozzleSize = nozzleSize;
            this.filterSize = filterSize;
            this.transformerType = transformerType;
            this.circulatorType = circulatorType;
        }
    }
}