
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingComponent
{
    public class Logging
    {
        //by using the pre-processordirective and relevant conditioinal attributes we can control to run which blocks of codes for more purpose
        //[Conditional("LOG_INFO")] ie. debug
        //by using obsolete attributes, we can inform others the current state of the method and even restrict to a compile error for altering
        [Obsolete("The LogToScreen method has now been deprecated. Please use the 'LogToFile' method instead", false)]
        public static void LogToScreen(string msg) 
        {
            Console.WriteLine(msg);
        }

        public static void LogToFile(string msg)
        {
            Console.WriteLine("Simulating logging text to file, " + msg);
        }
    }
}
