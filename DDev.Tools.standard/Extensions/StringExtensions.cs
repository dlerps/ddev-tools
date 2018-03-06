using System;
using System.Linq;

namespace DDev.Tools.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces a number of elements with a a given pattern that extends their occurances.
        /// For example: ExtendwithPattern("Hello World", "-{0}", { "l", "o" }) -> "He-l-l-o W-or-ld"
        /// </summary>
        /// <param name="s">The string.</param>
        /// <param name="pattern">The pattern including {0} to indicate where the original needs to be placed.</param>
        /// <param name="toReplace">The array with all the strings that will be replaced.</param>
        /// <returns></returns>
        public static string ExtendWithPattern(this string s, string pattern, params string[] toReplace)
        {
            if (pattern == null)
                throw new DDevToolsException("No pattern provided");
            else if (!pattern.Contains("{0}"))
                throw new DDevToolsException("The pattern needs to contain {0} as an indicator where the original needs to be placed.");

            if (String.IsNullOrEmpty(s) || toReplace == null || !toReplace.Any())
                return s;

            foreach (string tr in toReplace)
                s = s.Replace(tr, String.Format(pattern, tr));

            return s;
        }
    }
}