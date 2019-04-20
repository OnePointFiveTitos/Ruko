using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class ServiceTicket : TicketBase<Service, ServiceTicketModel>
    {
        public bool IsAnnualMaintenanceAndSafetyDiagnostic
        {
            get => Model.isAnnualMaintenanceAndSafetyDiagnostic;
            set
            {
                if (Model.isAnnualMaintenanceAndSafetyDiagnostic != value)
                {
                    Model.isAnnualMaintenanceAndSafetyDiagnostic = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsScheduled
        {
            get => Model.isScheduled;
            set
            {
                if (Model.isScheduled != value)
                {
                    Model.isScheduled = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ServiceType
        {
            get => Model.serviceType;
            set
            {
                if (Model.serviceType != value)
                {
                    Model.serviceType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string InstallationType
        {
            get => Model.installationType;
            set
            {
                if (Model.installationType != value)
                {
                    Model.installationType = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CoolingAndHeatingType
        {
            get => Model.coolingAndHeatingType;
            set
            {
                if (Model.coolingAndHeatingType != value)
                {
                    Model.coolingAndHeatingType = value;
                    OnPropertyChanged();
                }
            }
        }
        public ServiceTicket(Service parent, ServiceTicketModel model) : base(parent, model)
        {
        }
    }

    public class ServiceTicketModel : TicketBaseModel
    {
        internal bool isAnnualMaintenanceAndSafetyDiagnostic;
        internal bool isScheduled;
        internal string serviceType;
        internal string installationType;
        internal string coolingAndHeatingType;
    }
}