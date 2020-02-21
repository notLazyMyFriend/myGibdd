using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIN_LIB;
using System.Text.RegularExpressions;

namespace debug_dll
{
    class Program
    {
        static void Main(string[] args)                     //10
        {                                                //7  |
            Console.WriteLine(new Class1().GetTransportYear("JHMCM56557C404453"));
            Console.WriteLine(new Class1().GetVINCountry("JHMCM56557C404453"));
            Console.WriteLine(new Class1().CheckVIN("JHMCM56557C404453"));
            Console.ReadLine();
        }
    }
}
