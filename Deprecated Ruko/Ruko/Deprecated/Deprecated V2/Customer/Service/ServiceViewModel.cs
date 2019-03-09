using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;

namespace Ruko
{
    public class ServiceViewModel : MainInfoViewModel<ServiceModel>
    {
        public SystemViewModel Primary
        {
            get => Model.primary;
            set
            {
                if (Model.primary != value)
                {
                    Model.primary = value;
                    OnPropertyChanged();
                }
            }
        }
        public SystemViewModel Secondary
        {
            get => Model.secondary;
            set
            {
                if (Model.secondary != value)
                {
                    Model.secondary = value;
                    OnPropertyChanged();
                }
            }
        }
        public ServiceViewModel(CustomerViewModel parent, ServiceModel model) : base(parent, model)
        {
            Primary = new SystemViewModel(this, new SystemModel());
        }
    }
}