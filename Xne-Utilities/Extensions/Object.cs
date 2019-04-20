using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Xne_Utilities
{
    public static class Object
    {
        private static Random Random { get; } = new Random();
        private static JavaScriptSerializer Serializer { get; } = new JavaScriptSerializer();
        /// <summary>
        /// Checks is an object is equal to a Type
        /// </summary>
        public static bool IsType<T>(this object value) => value.GetType() == typeof(T);
        public static bool IsNotType<T>(this object value) => value.GetType() != typeof(T);
        /// <summary>
        /// Attempts to cast this object to (T)object. There's no error checking in this so use at your own risk.
        /// </summary>
        public static T Cast<T>(this object value) => (T)value;
        /// <summary>
        /// Serializes an object to a JSON string
        /// </summary>
        /// <param name="useNewInstance">Toggles whether to use a new instance of JavaScriptSerializer or the static one. This allows for async ops rather than needing to lock the static one</param>
        public static string ObjectToJson<T>(this T value, bool useNewInstance = false) => useNewInstance ? new JavaScriptSerializer().Serialize(value) : Serializer.Serialize(value);
        /// <summary>
        /// Checks that at least one value is not null
        /// </summary>
        public static bool IsAtLeastOneNotNull<T>(this IEnumerable<T> values) => values.Any(value => value != null);
        /// <summary>
        /// Checks that all values are not null
        /// </summary>
        public static bool AreAllNotNull<T>(this IEnumerable<T> values) => values.All(value => value != null);
        /// <summary>
        /// Returns all values that are not null, and replaces any null values with fallback values
        /// </summary>
        public static IEnumerable<T> ReturnAllThatAreNotNull<T>(this IEnumerable<T> values, T fallbackValue) => values.Select(value => value != null ? value : fallbackValue);
        public static T ReturnRandomElement<T>(this T[] values) => values[Random.Next(values.Length - 1)];
        public static T Initialize<T>(this T value, Func<T, T> initializer) => initializer(value);
        public static T At<T>(this IEnumerable<T> values, int index) => values.ElementAt(index);
        public static void SetIfNotEqual<T>(this T value, T newValue) => value = value.Equals(newValue) ? value : newValue;
    }
}