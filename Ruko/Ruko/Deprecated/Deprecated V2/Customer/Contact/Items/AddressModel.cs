using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Functions;

namespace Ruko
{
    public class AddressModel : ContactInfoModel
    {
        internal string street;
        internal string city;
        internal string state;
        internal string fullZipcode;
        internal string zipcode;
        internal string extension;
        internal string crossStreet;

        public AddressModel(string full) : base(full)
        {
        }

        public AddressModel(string street, string city, string state, string zipcode, string extension = null)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
            this.extension = extension;
            fullZipcode = string.Format("{0}{1}", zipcode, IsNotNEW(extension) ? $"-{extension}" : string.Empty);
        }
    }
}