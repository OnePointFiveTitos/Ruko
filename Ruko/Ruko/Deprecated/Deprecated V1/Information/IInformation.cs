using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public interface IInformation
    {
        bool IsRequired { get; set; }
        bool IsValid { get; set; }
        bool IsPrimary { get; set; }
    }
}