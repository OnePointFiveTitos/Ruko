using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public abstract class ContactInfoModel : SubInfoModel
    {
        internal string full;
        internal bool useConcatFull;

        public ContactInfoModel()
        {

        }

        public ContactInfoModel(string full)
        {
            this.full = full;
        }
    }
}
