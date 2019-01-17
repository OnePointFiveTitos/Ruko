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
    public class SystemUpdateViewModel : NodeViewModel<ServiceTicketViewModel, SystemUpdateModel>
    {
        public SystemUpdateViewModel(ServiceTicketViewModel parent, SystemUpdateModel model) : base(parent, model)
        {

        }
    }

    public class SystemUpdateModel
    {

    }
}