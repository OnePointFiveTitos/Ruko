using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ruko
{
    public class RukoModel
    {
        internal bool isAddingNewCustomer = false;
        internal NewCustomerViewModel newCustomer;

        internal CustomerViewModel selectedCustomer;
        internal CustomerViewModel selectedOpenedCustomer;

        internal IEnumerable<CustomerViewModel> selectedCustomers;
        internal IEnumerable<CustomerViewModel> selectedOpenedCustomers;

        internal double selectedFontSize = 12d;
        internal double[] fontSizes;
    }
}