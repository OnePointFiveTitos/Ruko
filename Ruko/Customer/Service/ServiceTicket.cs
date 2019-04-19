using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class ServiceTicket
    {
    }

    public class ServiceTicketModel
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

        internal bool isAnnualMaintenanceAndSafetyDiagnostic;
        internal bool isScheduled;
        internal string serviceType;
        internal string installationType;
        internal string coolingHeatingType;
    }
}