using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class ServiceViewModel : NodeViewModel<CustomerViewModel, ServiceModel>
    {
        public ServiceViewModel(CustomerViewModel parent, ServiceModel model) 
            : base(parent, model)
        {
        }
    }
}