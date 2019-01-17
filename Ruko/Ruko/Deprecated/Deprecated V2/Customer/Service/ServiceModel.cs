using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class ServiceModel : MainInfoModel
    {
        internal SystemViewModel primary;
        internal SystemViewModel secondary;

        public ServiceModel(SystemViewModel primary, SystemViewModel secondary = null)
        {
            this.primary = primary;
            this.secondary = secondary;
        }
        public ServiceModel()
        {

        }
    }
}