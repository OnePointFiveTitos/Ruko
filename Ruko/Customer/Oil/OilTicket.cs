using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class OilTicket : NodeViewModel<Oil, OilTicketModel>
    {
        public OilTicket(Oil parent, OilTicketModel model) : base(parent, model)
        {
        }
    }

    public class OilTicketModel
    {
        internal DateTime date;
        internal Name name;
        internal Address address;
        internal string timeIn;
        internal string timeOut;
        internal string technician;
        internal string remarks;
        internal float subTotal;
        internal float tax;
        internal float total;
        internal string payementType;

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