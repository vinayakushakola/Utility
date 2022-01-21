using System;
using Utility.Arrays;

namespace ConsoleApp
{
    class StartApp
    {
        public static void LoadApp()
        {
            bool start = true;
            StartApp startApp = new StartApp();
            while (start)
            {
                Console.WriteLine("Select Any Option");
                Console.WriteLine("1. Arrays");
                Console.WriteLine("2. Exit");
                int choice;
                bool IsValidChoice;
                do
                {
                    Console.Write("Enter Your Choice: ");
                    IsValidChoice = int.TryParse(Console.ReadLine(), out choice);
                    if (!IsValidChoice)
                        Console.WriteLine("Please Enter Number!");
                } while (!IsValidChoice);
                    
                switch ((typeDS)choice)
                {
                    case typeDS.Arrays:
                        startApp.ShowArrayOption();
                        break;
                    case typeDS.Exit:
                        start = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!\nChoose From {0} to {1}", typeDS.Arrays.GetHashCode(), typeDS.Exit);
                        break;
                }
            }
        }

        private void ShowArrayOption()
        {
            bool flag = true;
            Console.WriteLine("1. Arrays");
            while (flag)
            {
                Console.WriteLine("\ta. BasicArrays\n\tb. PrefixArrays\n\tc. CarryForwardArray\n\td. Exit");
                char choice = Convert.ToChar(Console.ReadLine().ToUpper());
                switch ((typeArrays)choice)
                {
                    case typeArrays.BasicArray:
                        break;
                    case typeArrays.PrefixArray:
                        break;
                    case typeArrays.CarryForwardArray:
                        string ip = "ACGAAG";
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("I/P: {0}", ip);
                        Console.WriteLine("O/P: Count = {0}", CarryForwardArray.FindPairCount(ip));
                        Console.WriteLine("-------------------------------------------------------");
                        break;
                    case typeArrays.Exit:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!\nChoose From a. {0} to d. {1}",
                            typeArrays.BasicArray, typeArrays.Exit);
                        break;
                }
            }
        }
    }
}
