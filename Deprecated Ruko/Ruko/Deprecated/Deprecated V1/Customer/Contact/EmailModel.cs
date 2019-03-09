using Enums;

namespace Ruko
{
    public class EmailModel : InformationModel
    {
        internal EmailTypes type = EmailTypes.Personal;
        internal bool isPreferred;
        public EmailModel(string full) : base(full)
        {
        }
    }
}