using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class GeneralInfo : AccountItem<GeneralInfoModel>
    {
        public GeneralInfo(Account parent, GeneralInfoModel model) : base(parent, model)
        {
        }
    }

    public class GeneralInfoModel : AccountItemModel
    {
        internal string id;
        internal string status;
        internal string standing;
        internal string lead;
    }
}