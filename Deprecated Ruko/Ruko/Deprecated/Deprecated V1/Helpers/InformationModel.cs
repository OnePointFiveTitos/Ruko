using MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ruko
{
    public class InformationModel
    {
        internal string full;
        internal bool isPrimary;
        internal bool isValid;
        internal bool isRequired;
        public InformationModel(string full)
        {
            this.full = full;
        }
    }
}