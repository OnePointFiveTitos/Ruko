using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public interface ITicket
    {
        DateTime Date { get; set; }
        Name Name { get; set; }
        Address Address { get; set; }
        DateTime TimeIn { get; set; }
        DateTime TimeOut { get; set; }
        string Technician { get; set; }
        string Remarks { get; set; }
        float SubTotal { get; set; }
        float Tax { get; set; }
        float Total { get; set; }
        string PayementType { get; set; }
    }
}