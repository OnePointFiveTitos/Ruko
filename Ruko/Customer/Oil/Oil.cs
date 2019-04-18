using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;

namespace Ruko
{
    public class Oil : NodeViewModel<Customer, OilModel>
    {
        public Oil(Customer parent, OilModel model) : base(parent, model)
        {
        }
    }

    public class OilModel
    {

    }
}