using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class OilTicket : TicketBase<Oil, OilTicketModel>
    {
        public float Gallons
        {
            get => Model.gallons;
            set
            {
                if (Model.gallons != value)
                {
                    Model.gallons = value;
                    OnPropertyChanged();
                }
            }
        }
        public float PricePerGallon
        {
            get => Model.pricePerGallon;
            set
            {
                if (Model.pricePerGallon != value)
                {
                    Model.pricePerGallon = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Discount
        {
            get => Model.discount;
            set
            {
                if (Model.discount != value)
                {
                    Model.discount = value;
                    OnPropertyChanged();
                }
            }
        }
        public float DeliveryCharge
        {
            get => Model.deliveryCharge;
            set
            {
                if (Model.deliveryCharge != value)
                {
                    Model.deliveryCharge = value;
                    OnPropertyChanged();
                }
            }
        }
        public string WorkType
        {
            get => Model.workType;
            set
            {
                if (Model.workType != value)
                {
                    Model.workType = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsTaxable
        {
            get => Model.isTaxable;
            set
            {
                if (Model.isTaxable != value)
                {
                    Model.isTaxable = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TaxID
        {
            get => Model.taxID;
            set
            {
                if (Model.taxID != value)
                {
                    Model.taxID = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TaxRate
        {
            get => Model.taxRate;
            set
            {
                if (Model.taxRate != value)
                {
                    Model.taxRate = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsTankFilled
        {
            get => Model.isTankFilled;
            set
            {
                if (Model.isTankFilled != value)
                {
                    Model.isTankFilled = value;
                    OnPropertyChanged();
                }
            }
        }
        public int InvoiceNumber
        {
            get => Model.invoiceNumber;
            set
            {
                if (Model.invoiceNumber != value)
                {
                    Model.invoiceNumber = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool SendCopy
        {
            get => Model.sendCopy;
            set
            {
                if (Model.sendCopy != value)
                {
                    Model.sendCopy = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Reference
        {
            get => Model.reference;
            set
            {
                if (Model.reference != value)
                {
                    Model.reference = value;
                    OnPropertyChanged();
                }
            }
        }

        public OilTicket(Oil parent, OilTicketModel model) : base(parent, model)
        {
        }
    }

    public class OilTicketModel : TicketBaseModel
    {
        internal float gallons;
        internal float pricePerGallon;
        internal float discount;
        internal float deliveryCharge;
        internal string workType;
        internal bool isTaxable;
        internal string taxID;
        internal string taxRate;
        internal bool isTankFilled;
        internal int invoiceNumber;
        internal bool sendCopy;
        internal string reference;
    }
}