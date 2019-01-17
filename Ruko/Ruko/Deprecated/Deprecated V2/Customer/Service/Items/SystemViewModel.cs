using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace Ruko
{
    public class SystemViewModel : NodeViewModel<ServiceViewModel, SystemModel>
    {
        public string BoilerMake
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
        public string PrimaryType
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
        public string SecondaryType
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
        public string TransformerType
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
        public string CirculatorType
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

        public SystemViewModel(ServiceViewModel parent, SystemModel model) : base(parent, model)
        {
        }
    }
}