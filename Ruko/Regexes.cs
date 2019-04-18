using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ruko
{
    public static class Regexes
    {
        public static Regex NameValidationExpression { get; } = new Regex(@"(\b[a-zA-Z0-9]+\b)(\s\b[a-zA-Z0-9]+\b)?(\s\b[a-zA-Z0-9]+\b)", RegexOptions.Compiled);
        public static Regex AddressValidationExpression { get; } = new Regex(@"", RegexOptions.Compiled);
        public static Regex EmailValidationExpression { get; } = new Regex(@"^(.+?)@(.+?)\.(.+)$", RegexOptions.Compiled);
        public static Regex PhoneValidationExpression { get; } = new Regex(@"(\d{3})-(\d{3})-(\d{4})", RegexOptions.Compiled);
    }
}