using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xne_MVVM;
using Xne_Utilities;

namespace Ruko
{
    public abstract class SectionBase<TModel> : RukoObject<Customer, TModel>, ISection where TModel : SectionBaseModel
    {
        public SectionBase(Customer parent, TModel model) : base(parent, model)
        {
        }
    }

    public abstract class SectionBaseModel : RukoObjectModel
    {
    }
}
