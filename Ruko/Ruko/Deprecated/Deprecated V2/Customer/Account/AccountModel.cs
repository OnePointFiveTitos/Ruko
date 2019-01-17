using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class AccountModel : MainInfoModel
    {
        internal string id;
        internal string status;
        internal string standing;
        internal string lead;

        public AccountModel(string status, string standing, string lead)
        {
            this.status = status;
            this.standing = standing;
            this.lead = lead;
        }

        public AccountModel()
        {

        }
    }
}