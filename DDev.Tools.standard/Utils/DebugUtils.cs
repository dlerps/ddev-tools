using System;
using System.Collections.Generic;
using System.Text;

namespace DDev.Tools.Utils
{
    public static class DebugUtils
    {
        /// <summary>
        /// Convenience method which combines String.Format and Console.WriteLine(...)
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="msgParams"></param>
        public static void Print(string msg, params object[] msgParams)
        {
            Console.WriteLine(String.Format(msg, msgParams));
        }
    }
}
