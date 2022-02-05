using System;
using System.Collections.Generic;
using Utility.Arrays;
using Utility.BitManipulation;
using Utility.ModularArithmetic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================== Utility ===================");
            //StartApp.LoadApp();
            Console.WriteLine(   ModularArithmetic.FindMod("143", 2));
            Console.WriteLine(   ModularArithmetic.FindMod("43535321", 47));
        }
    }
}
