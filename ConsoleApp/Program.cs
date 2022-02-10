using System;
using System.Collections.Generic;
using Utility.Arrays;
using Utility.BitManipulation;
using Utility.ModularArithmetic;
using Utility.DSA.Sorting;
using Utility.Strings;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================== Utility ===================");
            //StartApp.LoadApp();
            Console.WriteLine("Occurence Count = "+ Strings.CountOccurrences("aobob"));
            Console.WriteLine("O/P = "+ Strings.StringOperations("AbcaZeoB"));
        }
    }
}
