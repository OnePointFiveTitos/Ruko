using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Xne_Utilities
{
    public static class String
    {
        private static char[] Delimiters { get; } = { '|', ',', ' ', ';', ':', '/', '\\' };
        private static JavaScriptSerializer Deserializer { get; } = new JavaScriptSerializer();
        /// <summary>
        /// Checks to see if the string is Null, Empty or Whitespace (NEW)
        /// </summary>
        public static bool IsNEW(this string value) => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
        /// <summary>
        /// Checks to see if the string is NOT Null, Empty or Whitespace (NEW)
        /// </summary>
        public static bool IsNotNEW(this string value) => !value.IsNEW();
        /// <summary>
        /// Returns a fallback value if this string is NEW
        /// </summary>
        public static string ReturnIfNEW(this string value, string fallbackValue = null) => value.IsNEW() ? fallbackValue : value;
        /// <summary>
        /// Sets a fallback value is this string is NEW
        /// </summary>
        public static void SetIfNEW(this string value, string fallbackValue) => value = value.IsNEW() ? fallbackValue : value;
        /// <summary>
        /// Checks that at least one string is not NEW
        /// </summary>
        public static bool IsAtLeastOneNotNEW(this IEnumerable<string> values) => values.Any(value => value.IsNotNEW());
        /// <summary>
        /// Checks that all strings are not NEW
        /// </summary>
        public static bool AreAllNotNEW(this IEnumerable<string> values) => values.All(value => value.IsNotNEW());
        /// <summary>
        /// Returns all values that are not null, and replaces any null values with fallback values
        /// </summary>
        public static IEnumerable<string> ReturnAllThatAreNotNEW(this IEnumerable<string> values, string fallbackValue = null) => values.Select(value => value.ReturnIfNEW(fallbackValue));
        /// <summary>
        /// Tries to parse this string to a bool, returning a fallback value if it fails
        /// </summary>
        public static bool TryBoolParse(this string value, bool fallbackValue = false)
        {
            bool result;
            return bool.TryParse(value, out result) ? result : fallbackValue;
        }
        /// <summary>
        /// Tries to parse this string to a byte, returning a fallback value if it fails
        /// </summary>
        public static byte TryByteParse(this string value, byte fallbackValue = 0)
        {
            byte result;
            return byte.TryParse(value, out result) ? result : fallbackValue;
        }
        /// <summary>
        /// Tries to parse this string to a short, returning a fallback value if it fails
        /// </summary>
        public static short TryShortParse(this string value, short fallbackValue = -1)
        {
            short result;
            return short.TryParse(value, out result) ? result : fallbackValue;
        }
        /// <summary>
        /// Tries to parse this string to a int, returning a fallback value if it fails
        /// </summary>
        public static int TryIntParse(this string value, int fallbackValue = -1)
        {
            int result;
            return int.TryParse(value, out result) ? result : fallbackValue;
        }
        /// <summary>
        /// Tries to parse this string to a float, returning a fallback value if it fails
        /// </summary>
        public static float TryFloatParse(this string value, float fallbackValue = -1)
        {
            float result;
            return float.TryParse(value, out result) ? result : fallbackValue;
        }
        /// <summary>
        /// Tries to parse this string to a double, returning a fallback value if it fails
        /// </summary>
        public static double TryDoubleParse(this string value, double fallbackValue = -1)
        {
            double result;
            return double.TryParse(value, out result) ? result : fallbackValue;
        }
        /// <summary>
        /// Tries to parse this string to a decimal, returning a fallback value if it fails
        /// </summary>
        public static decimal TryDecimalParse(this string value, decimal fallbackValue = -1)
        {
            decimal result;
            return decimal.TryParse(value, out result) ? result : fallbackValue;
        }
        /// <summary>
        /// Tries to parse this string to a long, returning a fallback value if it fails
        /// </summary>
        public static long TryLongParse(this string value, long fallbackValue = -1)
        {
            long result;
            return long.TryParse(value, out result) ? result : fallbackValue;
        }
        /// <summary>
        /// Tries to parse a string to a DateTime, returning a fallback value if it fails
        /// </summary>
        public static DateTime TryDateTimeParse(this string value, DateTime optionalDateTime = default)
        {
            DateTime result;
            return DateTime.TryParse(value, out result) ? result : optionalDateTime;
        }
        /// <summary>
        /// Tries to parse this string to a TEnum, returning a fallback value if it fails
        /// </summary>
        /// <typeparam name="TEnum">The typeof enumeration to parse to</typeparam>
        /// <param name="fallbackValue">A fallback value if the parse fails. This will be the first value listed within the actual enumeration type</param>
        public static TEnum TryEnumParse<TEnum>(this string value, TEnum fallbackValue = default(TEnum)) where TEnum : struct
        {
            TEnum result;
            return Enum.TryParse(value, out result) ? result : fallbackValue;
        }
        /// <summary>
        /// Deserializes a JSON string into an object of a specified T type.
        /// NOTE: Make sure the object class you're deserializing to has a default, parameterless constructor.
        /// </summary>
        /// <param name="useNewInstance">Toggles whether to use a new instance of JavaScriptSerializer or the static one. This allows for async ops rather than needing to lock the static one</param>
        public static T JsonToObject<T>(this string value, bool useNewInstance = false) => useNewInstance ? new JavaScriptSerializer().Deserialize<T>(value) : Deserializer.Deserialize<T>(value);
        public static Match Match(this string value, Regex expression) => expression.Match(value);
        public static MatchCollection Matches(this string value, Regex expression) => expression.Matches(value);
        public static GroupCollection Groups(this string value, Regex expression) => value.Match(expression).Groups;
        /// <summary>
        /// Splits the string using the following chars -> '|', ',', ' ', ';', ':', '/', '\\'
        /// </summary>
        public static string[] SplitDefault(this string value, StringSplitOptions option = StringSplitOptions.RemoveEmptyEntries) => value.Split(Delimiters, option);
    }
}