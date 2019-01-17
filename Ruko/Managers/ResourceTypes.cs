using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    /// <summary>
    /// Represents a type of resource
    /// </summary>
    public enum ResourceTypes : byte
    {
        /// <summary>
        /// Represents a node in an application directory tree
        /// </summary>
        Directory,
        /// <summary>
        /// Compile and likewise resources
        /// </summary>
        Internal,
        /// <summary>
        /// User accessible and editable resources
        /// </summary>
        External
    }
}