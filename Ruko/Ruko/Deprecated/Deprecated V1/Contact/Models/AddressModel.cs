using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public class AddressModel : AssociationModel
    {
        internal string street;
        internal string city;
        internal string state;
        internal int zipCode;
        internal int? zipCodeExtension;
        public AddressModel(string street, string city, string state, int zipCode, int? zipCodeExtension = null)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.zipCodeExtension = zipCodeExtension;
        }
    }
}