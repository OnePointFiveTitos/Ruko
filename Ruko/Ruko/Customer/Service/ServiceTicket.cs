using System;
namespace Ruko
{
    public class ServiceTicketViewModel : TicketViewModel<ServiceViewModel, ServiceTicketModel>
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
        public UserParameter ServiceType
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
        public UserParameter InstallationType
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
        public UserParameter CoolingHeatingType
        {
            get => Model.coolingHeatingType;
            set
            {
                if (Model.coolingHeatingType != value)
                {
                    Model.coolingHeatingType = value;
                    OnPropertyChanged();
                }
            }
        }
        public SystemUpdateViewModel PrimaryUpdate
        {
            get => Model.primaryUpdate;
            set
            {
                if (Model.primaryUpdate != value)
                {
                    Model.primaryUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        public SystemUpdateViewModel SecondaryUpdate
        {
            get => Model.secondaryUpdate;
            set
            {
                if (Model.secondaryUpdate != value)
                {
                    Model.secondaryUpdate = value;
                    OnPropertyChanged();
                }
            }
        }

        public ServiceTicketViewModel(ServiceViewModel parent, ServiceTicketModel model) : base(parent, model)
        {

        }
    }

    public class ServiceTicketModel : TicketModel
    {
        internal bool isAnnualMaintenanceAndSafetyDiagnostic;
        internal bool isScheduled;
        internal UserParameter serviceType;
        internal UserParameter installationType;
        internal UserParameter coolingHeatingType;
        internal SystemUpdateViewModel primaryUpdate;
        internal SystemUpdateViewModel secondaryUpdate;

        public ServiceTicketModel(bool isAnnualMaintenanceAndSafetyDiagnostic, bool isScheduled, UserParameter serviceType, UserParameter installationType, UserParameter coolingHeatingType, SystemUpdateViewModel primaryUpdate, SystemUpdateViewModel secondaryUpdate, DateTime date, NameViewModel name, AddressViewModel address, string timeIn, string timeOut, string technician, string remarks, UserParameter payementType) : base(date, name, address, timeIn, timeOut, technician, remarks, payementType)
        {
            this.isAnnualMaintenanceAndSafetyDiagnostic = isAnnualMaintenanceAndSafetyDiagnostic;
            this.isScheduled = isScheduled;
            this.serviceType = serviceType;
            this.installationType = installationType;
            this.coolingHeatingType = coolingHeatingType;
            this.primaryUpdate = primaryUpdate;
            this.secondaryUpdate = secondaryUpdate;
        }
    }
}