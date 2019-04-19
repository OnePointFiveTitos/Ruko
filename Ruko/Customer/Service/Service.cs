using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Service : SectionBase<ServiceModel>
    {
        public Service(Customer parent, ServiceModel model) : base(parent, model)
        {
        }
    }

    public class ServiceModel : SectionBaseModel
    {

    }
}