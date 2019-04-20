using System;

namespace Ruko
{
    public abstract class TicketBase<TParent, TModel> : SectionItemBase<TParent, TModel>, ITicket where TModel : TicketBaseModel
    {
        public virtual DateTime Date
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
        public virtual Name Name
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
        public virtual Address Address
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
        public virtual DateTime TimeIn
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
        public virtual DateTime TimeOut
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
        public virtual string Technician
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
        public virtual string Remarks
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
        public virtual float SubTotal
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
        public virtual float Tax
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
        public virtual float Total
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
        public virtual string PayementType
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

        public TicketBase(TParent parent, TModel model) : base(parent, model)
        {
        }
    }

    public abstract class TicketBaseModel : SectionItemBaseModel
    {
        internal DateTime date;
        internal Name name;
        internal Address address;
        internal DateTime timeIn;
        internal DateTime timeOut;
        internal string technician;
        internal string remarks;
        internal float subTotal;
        internal float tax;
        internal float total;
        internal string payementType;
    }
}