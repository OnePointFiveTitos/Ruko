using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Regexes
    {
        /// <summary>
        /// Group 1: Handle
        /// Group 2: Domain
        /// Group 3: Register
        /// Groups to use: 1, 2, 3
        /// </summary>
        public static readonly Regex NameEx = new Regex(@"^([a-zA-Z0-9]+)\s([a-zA-Z0-9-]+\s)??([a-zA-Z0-9]+)$", RegexOptions.Compiled);
        /// <summary>
        /// These are the indices of the capture groups that are used from the regex match
        /// </summary>
        public static readonly int[] NameIndices = { 1, 2, 3 };
        /// <summary>
        /// Group 1: Street
        /// Group 2: City & State
        /// Group 3: City
        /// Group 4: State
        /// Group 5: Zipcode & Extension
        /// Group 6: Zipcode
        /// Group 7: -Extension
        /// Group 8: Extension
        /// Groups to use: 1, 3, 4, 6, 8 (or 7 for full)
        /// </summary>
        public static readonly Regex AddressEx = new Regex(@"^(.+)\s?,\s?((.+) (.+))\s?,\s?((\d+)(-(\d+))?)$", RegexOptions.Compiled);
        /// <summary>
        /// These are the indices of the capture groups that are used from the regex match
        /// </summary>
        public static readonly int[] AddressIndices = { 1, 3, 4, 6, 7, 8 };
        /// <summary>
        /// Group 1: Handle
        /// Group 2: Domain
        /// Group 3: Register
        /// Groups to use: 1, 2, 3
        /// </summary>
        public static readonly Regex EmailEx = new Regex(@"^(.+)@(.+)\.(.+)$", RegexOptions.Compiled);
        /// <summary>
        /// These are the indices of the capture groups that are used from the regex match
        /// </summary>
        public static readonly int[] EmailIndices = { 1, 2, 3 };
        /// <summary>
        /// Group 1: Areacode
        /// Group 2: Prefix
        /// Group 3: LineNumber
        /// Groups to use: 1, 2, 3
        /// </summary>
        public static readonly Regex PhoneEx = new Regex(@"^(\d{3})-(\d{3})-(\d{4})$", RegexOptions.Compiled);
        /// <summary>
        /// These are the indices of the capture groups that are used from the regex match
        /// </summary>
        public static readonly int[] PhoneIndices = { 1, 2, 3 };
    }
}