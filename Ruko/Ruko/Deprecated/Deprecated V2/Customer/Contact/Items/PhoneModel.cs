using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Ruko
{
    public class PhoneModel : ContactInfoModel
    {
        internal string country;
        internal string areacode;
        internal string prefix;
        internal string line;
        internal string extension;

        public PhoneModel(string full) : base(full)
        {
        }

        public PhoneModel(string country, string areacode, string prefix, string line, string extension)
        {
            this.country = country;
            this.areacode = areacode;
            this.prefix = prefix;
            this.line = line;
            this.extension = extension;
        }
    }
}