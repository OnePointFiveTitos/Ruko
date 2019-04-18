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
    public class Name : NodeViewModel<ContactProfile, NameModel>
    {
        public Name(ContactProfile parent, NameModel model) : base(parent, model)
        {
        }
    }

    public class NameModel
    {
    }
}