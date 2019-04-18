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
    public class Phone : NodeViewModel<ContactProfile, PhoneModel>
    {
        public Phone(ContactProfile parent, PhoneModel model) : base(parent, model)
        {
        }
    }

    public class PhoneModel
    {
        internal int areacode;
        internal int prefix;
        internal int line;
        internal int? country;
        internal int? extension;
    }
}