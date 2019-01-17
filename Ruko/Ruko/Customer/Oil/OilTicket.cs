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
    public class OilTicketViewModel : TicketViewModel<OilViewModel, OilTicketModel>
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
        public UserParameter WorkType
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
        public UserParameter TaxID
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
        public UserParameter TaxRate
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

        public OilTicketViewModel(OilViewModel parent, OilTicketModel model) : base(parent, model)
        {
        }
    }

    public class OilTicketModel : TicketModel
    {
        internal float gallons;
        internal float pricePerGallon;
        internal float discount;
        internal float deliveryCharge;
        internal UserParameter workType;
        internal bool isTaxable;
        internal UserParameter taxID;
        internal UserParameter taxRate;
        internal bool isTankFilled;
        internal int invoiceNumber;
        internal bool sendCopy;
        internal string reference;

        public OilTicketModel(float gallons, float pricePerGallon, float discount, float deliveryCharge, UserParameter workType, bool isTaxable, UserParameter taxID, UserParameter taxRate, bool isTankFilled, int invoiceNumber, bool sendCopy, string reference, DateTime date, NameViewModel name, AddressViewModel address, string timeIn, string timeOut, string technician, string remarks, UserParameter payementType) : base(date, name, address, timeIn, timeOut, technician, remarks, payementType)
        {
            this.gallons = gallons;
            this.pricePerGallon = pricePerGallon;
            this.discount = discount;
            this.deliveryCharge = deliveryCharge;
            this.workType = workType;
            this.isTaxable = isTaxable;
            this.taxID = taxID;
            this.taxRate = taxRate;
            this.isTankFilled = isTankFilled;
            this.invoiceNumber = invoiceNumber;
            this.sendCopy = sendCopy;
            this.reference = reference;
        }
    }
}