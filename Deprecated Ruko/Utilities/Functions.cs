using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Utilities
{
    public static class Functions
    {
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

        //Object Null checking

        /// <summary>
        /// Checks to see if an object is null
        /// </summary>
        public static bool IsNull(object obj) 
            => obj == null;

        /// <summary>
        /// Checks to see if an object is not null
        /// </summary>
        public static bool IsNotNull(object obj)
            => !IsNull(obj);

        /// <summary>
        /// Checks to see if at least one object is not null
        /// </summary>
        public static bool AtLeastOneIsNotNull(params object[] objs)
            => objs.Any(obj => IsNotNull(obj));

        /// <summary>
        /// Checks to see if all objects are not null
        /// </summary>
        public static bool AllAreNotNull(params object[] objs)
            => objs.All(obj => IsNotNull(obj));

        /// <summary>
        /// Checks to see if the objects are null and returns an enumerable of any that aren't
        /// </summary>
        public static IEnumerable<T> ReturnAllNonNull<T>(params T[] objs) 
            => objs.Where(obj => IsNotNull(obj));

        /// <summary>
        /// Checks to see if an object is not null and returns it if so, else returns an optional fallback object
        /// </summary>
        public static T ReturnIfNotNull<T>(T obj, T fallbackObj = null) where T : class
            => IsNotNull(obj) 
            ? obj 
            : fallbackObj;

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

        ///// <summary>
        ///// Evaluates an object with a regex and breaks out the data into smaller more refined bits. IE: and Address => Street, City, State, Zipcode, Extension etc
        ///// </summary>
        ///// <param name="obj"></param>
        ///// <param name="regex"></param>
        ///// <param name="value"></param>
        ///// <param name="groupIndices"></param>
        //public static void Evaluate(object obj, Regex regex, string value, int[] groupIndices)
        //{
        //    PropertyInfo[] properties = obj.GetType().GetProperties();
        //    GroupCollection groups = regex.Match(value).Groups;
        //    for (int i = 0; i < properties.Length; i++)
        //    {
        //        properties[i].SetValue(obj, groups[groupIndices[i]]);
        //    }
        //}
    }
}