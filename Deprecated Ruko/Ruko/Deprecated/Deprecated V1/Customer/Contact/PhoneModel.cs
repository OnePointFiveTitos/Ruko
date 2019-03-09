using Enums;

namespace Ruko
{
    public class PhoneModel : InformationModel
    {
        internal PhoneTypes type = PhoneTypes.Personal;
        internal bool isPreferred;
        public PhoneModel(string full) : base(full)
        {
        }
    }
}