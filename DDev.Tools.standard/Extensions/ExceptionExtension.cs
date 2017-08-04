using System;
using System.Collections.Generic;
using System.Text;

namespace DDev.Tools.Extensions
{
    public static class ExceptionExtension
    {
        /// <summary>
        /// Prints the stack trace information of a exception
        /// </summary>
        /// <param name="e"></param>
        public static void Print(this Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);

            if (e.InnerException != null)
            {
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }
        }
    }
}
