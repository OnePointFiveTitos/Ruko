using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class PhoneModel : AssociationModel
    {
        internal string phone;
        internal int? extension;
        internal int? countryCode;
        public PhoneModel(string phone, int? extension = null, int? countryCode = null)
        {
            this.phone = phone;
            this.extension = extension;
            this.countryCode = countryCode;
        }
    }
}