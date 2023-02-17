using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 100);
            }

            int[] evenElements = array.Where(x => x % 2 == 0).ToArray();

            Console.WriteLine("Even elements:");
            foreach (int element in evenElements)
            {
                Console.WriteLine(element);
            }
            Console.ReadLine();
        }
    }
}
