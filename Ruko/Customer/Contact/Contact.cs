using System.Collections.Generic;

namespace Ruko
{
    public class Contact
    {
        public Name primaryName;
        public Address primaryAddress;
        public Email primaryEmail;
        public Phone primaryPhone;

        public IEnumerable<Name> names;
        public IEnumerable<Address> addresses;
        public IEnumerable<Email> emails;
        public IEnumerable<Phone> phones;
    }
}