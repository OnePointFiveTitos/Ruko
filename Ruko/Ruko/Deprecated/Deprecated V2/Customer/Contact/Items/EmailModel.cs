using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class EmailModel : ContactInfoModel
    {
        internal string handle;
        internal string domain;
        internal string register;

        public EmailModel(string full) : base(full)
        {
        }

        public EmailModel(string handle, string domain, string register)
        {
            this.handle = handle;
            this.domain = domain;
            this.register = register;
        }
    }
}