namespace Ruko
{
    public class Address : Information
    {
        public AddressTypes addressType;
        public int addressNumber;
        public string addressLine;
        public int optionalNumber;
        public StateTypes stateType;
        public string city;
        public string zip_code;
    }
}