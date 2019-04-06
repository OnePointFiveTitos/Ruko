using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xne_Utilities
{
    public static class Stringbuilder
    {
        /// <summary>
        /// Iterates over a length, repeatedly appending a value to the stringbuilder
        /// </summary>
        /// <param name="appendValue">The value to repeatedly append</param>
        /// <param name="length">The length to iterate over - this is exclusive</param>
        /// <param name="isAppendLine">Whether or not to append "\n" or not </param>
        /// <param name="isReversed">Whether or not to iterate from the beginning or from the end</param>
        public static StringBuilder ForAppend<T>(this StringBuilder builder, T appendValue, int length, bool isAppendLine, bool isReversed = false)
        {
            for (int i = isReversed ? length - 1 : 0; isReversed ? i >= 0 : i < length; i = isReversed ? i - 1 : i + 1)
            {
                builder.Append(string.Format("{0}{1}", appendValue, isAppendLine ? "\n" : ""));
            }
            return builder;
        }
        /// <summary>
        /// Iterates over an array, appending each value in the array to the stringbuilder
        /// </summary>
        /// <param name="appendValues">The array of values to iterate over and append to the stringbuilder</param>
        /// <param name="isAppendLine">Whether or not to append "\n" or not </param>
        /// <param name="isReversed">Whether or not to iterate from the beginning or from the end</param>
        public static StringBuilder ForAppend<T>(this StringBuilder builder, T[] appendValues, bool isAppendLine, bool isReversed = false) 
            => ForAppendAction(builder, appendValues, (sb, av) => sb.Append(string.Format("{0}{1}", av, isAppendLine ? "\n" : "")), isAppendLine);
        /// <summary>
        /// Iterates over an array, passing each value an Action that should ultimately append that value to the stringbuilder
        /// </summary>
        /// <param name="appendValues">The array of values to iterate over and append to the stringbuilder</param>
        /// <param name="action">The action that handles each value in the array and ultimately appends it to the stringbuilder</param>
        /// <param name="isAppendLine">Whether or not to append "\n" or not </param>
        /// <param name="isReversed">Whether or not to iterate from the beginning or from the end</param>
        /// <returns></returns>
        public static StringBuilder ForAppendAction<T>(this StringBuilder builder, T[] appendValues, Action<StringBuilder, T> action, bool isAppendLine, bool isReversed = false)
        {
            for (int i = isReversed ? appendValues.Length - 1 : 0; isReversed ? i >= 0 : i < appendValues.Length; i = isReversed ? i - 1 : i + 1)
            {
                action(builder, appendValues[i]);
            }
            return builder;
        }
        /// <summary>
        /// Iterates over a collection of values, appending each value in the  collection to the stringbuilder
        /// </summary>
        /// <param name="appendValues">The collection of values to iterate over and append to the stringbuilder</param>
        /// <param name="isAppendLine">Whether or not to append "\n" or not </param>
        public static StringBuilder ForeachAppend<T>(this StringBuilder builder, IEnumerable<T> appendValues, bool isAppendLine) 
            => ForeachAppendAction(builder, appendValues, (sb, av) => sb.Append(string.Format("{0}{1}", av, isAppendLine ? "\n" : "")));
        /// <summary>
        /// Iterates over a collection of values, passing each value to an Action that should ultimately append that value to the stringbuilder
        /// </summary>
        /// <param name="appendValues">The collection of values to iterate over and append to the stringbuilder</param>
        /// <param name="action">The action that handles each value in the colelction and ultimately appends it to the stringbuilder</param>
        public static StringBuilder ForeachAppendAction<T>(this StringBuilder builder, IEnumerable<T> appendValues, Action<StringBuilder, T> action)
        {
            foreach (T appendValue in appendValues)
            {
                action(builder, appendValue);
            }
            return builder;
        }
    }
}