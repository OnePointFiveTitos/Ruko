using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Functions;
using static Utilities.Regexes;
using Enums;
using MVVM;
using Managers;
using System.Windows.Input;
namespace Ruko
{
    public class ServiceViewModel : TicketableInfoViewModel<ServiceModel, ServiceTicketViewModel>
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

        public ServiceViewModel(CustomerViewModel parent, ServiceModel model) : base(parent, model, "Service")
        {
            //Model = Model ?? new ServiceModel(new SystemViewModel(this), new SystemViewModel(this));
        }
    }

    public class ServiceModel : TicketableInfoModel<ServiceTicketViewModel>
    {
        internal SystemViewModel primary;
        internal SystemViewModel secondary;

        public ServiceModel()
        {

        }

        public ServiceModel(SystemViewModel primary, SystemViewModel secondary = null)
        {
            this.primary = primary;
            this.secondary = secondary;
        }
    }
}