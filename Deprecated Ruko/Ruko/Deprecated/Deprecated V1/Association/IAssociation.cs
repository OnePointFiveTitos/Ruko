using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruko
{
    public interface IAssociation
    {
        NameViewModel AssociatedName { get; set; }
    }
}