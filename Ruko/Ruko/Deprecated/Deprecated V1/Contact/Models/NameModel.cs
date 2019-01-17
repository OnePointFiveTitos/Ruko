using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class NameModel : InformationModel
    {
        internal string name;
        public NameModel(string name)
        {
            this.name = name;
        }
    }
}