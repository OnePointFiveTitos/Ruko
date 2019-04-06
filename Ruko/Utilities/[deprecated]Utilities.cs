using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Utilities
{
    public static class Utilities
    {
        public static char[] Delimiters = { '|', ',', ' ', ';', ':', '/', '\\' };

        #region Json Serialization
        /// <summary>
        /// Deserializes a JSON string to an object
        /// </summary>
        public static T JsonToObject<T>(string json)
            => new JavaScriptSerializer().Deserialize<T>(json);

        /// <summary>
        /// Serializes an object to a JSON string
        /// </summary>
        public static string ObjectToJson<T>(T obj)
            => new JavaScriptSerializer().Serialize(obj);
        #endregion

        #region Object Null checkings and string Null, Empty, and Whitespace (NEW) checking
        //String NEW checking

        /// <summary>
        /// Checks to see if a string is Null, Empty, or Whitespace (NEW)
        /// </summary>
        public static bool IsNEW(string value)
            => string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Checks to see if a string is not Null, Empty, or Whitespace (NEW)
        /// </summary>
        public static bool IsNotNEW(string value)
            => !IsNEW(value);

        /// <summary>
        /// Checks to see if at least one value is not Null, Empty, or Whitespace (NEW)
        /// </summary>
        public static bool AtLeastOneIsNotNEW(params string[] values)
            => values.Any(value => IsNotNEW(value));

        /// <summary>
        /// Checks to see if all values are not Null, Empty, or Whitespace (NEW)
        /// </summary>
        public static bool AllAreNotNEW(params string[] values)
            => values.All(value => IsNotNEW(value));

        /// <summary>
        /// Checks to see if the values are Null, Empty, or Whitespace (NEW) and returns an enumerable of any that aren't
        /// </summary>
        public static IEnumerable<string> ReturnAllNonNEW(params string[] values)
            => values.Where(value => IsNotNEW(value));

        /// <summary>
        /// Checks to see if a string is not Null, Empty, or Whitespace (NEW) and returns it if so, else returns an optional fallback value
        /// </summary>
        public static string ReturnIfNotNEW(string value, string fallbackValue = null)
            => IsNotNEW(value)
            ? value
            : fallbackValue;
        #endregion
    }
}