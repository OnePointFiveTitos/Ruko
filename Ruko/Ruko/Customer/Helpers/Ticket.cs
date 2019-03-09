using System;
using MVVM;
namespace Ruko
{
    public abstract class TicketViewModel<TParent, TModel> : NodeViewModel<TParent, TModel>, ITicket where TModel : TicketModel
        where TParent : IViewModel
    {
        public bool IsSelected
        {
            get => Model.isSelected;
            set
            {
                if (Model.isSelected != value)
                {
                    Model.isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsOpened
        {
            get => Model.isOpened;
            set
            {
                if (Model.isOpened != value)
                {
                    Model.isOpened = value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Date
        {
            get => Model.date;
            set
            {
                if (Model.date != value)
                {
                    Model.date = value;
                    OnPropertyChanged();
                }
            }
        }
        public NameViewModel Name
        {
            get => Model.name;
            set
            {
                if (Model.name != value)
                {
                    Model.name = value;
                    OnPropertyChanged();
                }
            }
        }
        public AddressViewModel Address
        {
            get => Model.address;
            set
            {
                if (Model.address != value)
                {
                    Model.address = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TimeIn
        {
            get => Model.timeIn;
            set
            {
                if (Model.timeIn != value)
                {
                    Model.timeIn = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TimeOut
        {
            get => Model.timeOut;
            set
            {
                if (Model.timeOut != value)
                {
                    Model.timeOut = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Technician
        {
            get => Model.technician;
            set
            {
                if (Model.technician != value)
                {
                    Model.technician = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Remarks
        {
            get => Model.remarks;
            set
            {
                if (Model.remarks != value)
                {
                    Model.remarks = value;
                    OnPropertyChanged();
                }
            }
        }
        public float SubTotal
        {
            get => Model.subTotal;
            set
            {
                if (Model.subTotal != value)
                {
                    Model.subTotal = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Tax
        {
            get => Model.tax;
            set
            {
                if (Model.tax != value)
                {
                    Model.tax = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Total
        {
            get => Model.total;
            set
            {
                if (Model.total != value)
                {
                    Model.total = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserParameter PayementType
        {
            get => Model.payementType;
            set
            {
                if (Model.payementType != value)
                {
                    Model.payementType = value;
                    OnPropertyChanged();
                }
            }
        }

        public TicketViewModel(TParent parent, TModel model) : base(parent, model)
        {
        }
    }

    public abstract class TicketModel
    {
        internal bool isSelected = false;
        internal bool isOpened = false;
        internal DateTime date;
        internal NameViewModel name;
        internal AddressViewModel address;
        internal string timeIn;
        internal string timeOut;
        internal string technician;
        internal string remarks;
        internal float subTotal;
        internal float tax;
        internal float total;
        internal UserParameter payementType;

        public TicketModel(DateTime date, NameViewModel name, AddressViewModel address, string timeIn, string timeOut, string technician, string remarks, UserParameter payementType)
        {
            this.date = date;
            this.name = name;
            this.address = address;
            this.timeIn = timeIn;
            this.timeOut = timeOut;
            this.technician = technician;
            this.remarks = remarks;
            this.payementType = payementType;
        }
    }
}