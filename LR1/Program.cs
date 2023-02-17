using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LR11
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Action<string, int>, double, double> myDelegate;
            myDelegate = PerformCalculation;

            Action<string, int> someAction = (string message, int number) =>
            {
                Console.WriteLine(message + number);
            };

            double result = myDelegate(someAction, 2.5);
            Console.WriteLine("Result: " + result);
            Console.ReadKey();
        }

        static double PerformCalculation(Action<string, int> action, double input1)
        {
            action("The result is: ", (int)(input1));
            return input1;
        }
    }
}