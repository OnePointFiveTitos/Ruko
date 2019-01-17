using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Ruko
{
    public interface IContactMethod
    {
        bool IsPreferred { get; set; }
        ContactTypes Type { get; set; } 
    }
}