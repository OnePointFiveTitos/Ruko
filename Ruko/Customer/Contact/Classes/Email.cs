using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xne_MVVM;
using static Ruko.Regexes;

namespace Ruko
{
    public class Email : NodeViewModel<ContactProfile, EmailModel>
    {
        public Email(ContactProfile parent, EmailModel model) : base(parent, model)
        {
        }
    }

    public class EmailModel
    {
        internal string handle;
        internal string domain;
        internal string register;
    }
}