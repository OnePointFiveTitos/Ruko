using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public interface IInformationObject
    {
        string Full { get; set; }
        bool IsPrimary { get; set; }
        bool IsValid { get; set; }
        bool IsRequired { get; set; }
    }
}