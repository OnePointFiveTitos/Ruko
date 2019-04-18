using System.Text.RegularExpressions;
using Xne_MVVM;
using static Ruko.Regexes;

namespace Ruko
{
    public class Address : NodeViewModel<ContactProfile, AddressModel>
    {
        public Address(ContactProfile parent, AddressModel model) : base(parent, model)
        {
        }
    }

    public class AddressModel
    {
        internal string street;
        internal string city;
        internal int zipcode;
        internal int? extension;
        internal string crossStreet;
    }
}