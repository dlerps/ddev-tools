using System;
using System.Collections.Generic;
using System.Text;

namespace DDev.Tools.Extensions
{
    public static class NumericUtils
    {
        /// <summary>
        /// Safly converts this string to an integer.
        /// If the string is not convertable, it will retun a null.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int? ToInteger(this string s)
        {
            int num = 0;
            return Int32.TryParse(s, out num) ? (int?) num : null;
        }

        /// <summary>
        /// Safly converts this string to an double.
        /// If the string is not convertable, it will retun a null.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double? ToDouble(this string s)
        {
            double num = 0;
            return Double.TryParse(s, out num) ? (double?) num : null;
        }

        /// <summary>
        /// Safly converts this string to an decimal.
        /// If the string is not convertable, it will retun a null.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string s)
        {
            decimal num = 0;
            return Decimal.TryParse(s, out num) ? (decimal?) num : null;
        }

        /// <summary>
        /// Safly converts this string to an long.
        /// If the string is not convertable, it will retun a null.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long? ToLong(this string s)
        {
            long num = 0;
            return Int64.TryParse(s, out num) ? (long?) num : null;
        }
    }
}
