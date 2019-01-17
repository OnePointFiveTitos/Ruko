using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Utilities.Regexes;

namespace Ruko
{
    public class EmailModel : AssociationModel
    {
        internal string email;
        public EmailModel(string email)
        {
            this.email = email;
        }
    }
}