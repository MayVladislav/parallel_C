using System;
using System.Threading;

namespace CommonElementsThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] array2 = new int[] { 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            int commonCount = 0;
            ParameterizedThreadStart commonElements = (obj) =>
            {
                int[] arr = (int[])obj;
                for (int i = 0; i < array1.Length; i++)
                {
                    for (int j = 0; j < array2.Length; j++)
                    {
                        if (array1[i] == array2[j])
                        {
                            commonCount++;
                        }
                    }
                }
            };

            Thread t = new Thread(commonElements);
            t.Start(array1);
            t.Join();

            Console.WriteLine("Number of common elements: " + commonCount);
            Console.ReadLine();
        }
    }
}
