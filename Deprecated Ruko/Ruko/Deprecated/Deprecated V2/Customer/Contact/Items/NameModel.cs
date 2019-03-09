using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class NameModel : ContactInfoModel
    {
        internal string first;
        internal string middle;
        internal string last;

        public NameModel(string full) : base(full)
        {
        }

        public NameModel(string first, string middle, string last) //: base(string.Format("{0} {1}{2}", first, middle ?? string.Empty, last))
        {
            this.first = first;
            this.middle = middle;
            this.last = last;
        }
    }
}