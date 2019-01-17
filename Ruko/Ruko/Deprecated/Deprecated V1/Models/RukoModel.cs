using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class RukoModel
    {
        internal bool isAddingCustomer = false;
        internal CustomerViewModel selectedCustomer;
        internal CustomerViewModel selectedOpenedCustomer;
        internal AddCustomerViewModel addCustomerViewModel;
    }
}