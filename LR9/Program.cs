using System;
using System.Threading.Tasks;

namespace RandomArrayGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(1, 100);
            }

            Task task1 = Task.Run(() =>
            {
                int sum = 0;
                Console.WriteLine("Odd elements divisible by 7: ");
                for (int i = 0; i < size; i++)
                {
                    if (array[i] % 2 != 0 && array[i] % 7 == 0)
                    {
                        Console.Write(array[i] + " ");
                        sum += array[i];
                    }
                }
                Console.WriteLine("\nSum of the elements: " + sum);
            });

            Task task2 = Task.Run(() =>
            {
                int max = array[0];
                for (int i = 1; i < size; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }
                Console.WriteLine("Max element: " + max);
            });

            Task task3 = Task.Run(() =>
            {
                Console.WriteLine("Array elements: ");
                foreach (int element in array)
                {
                    Console.Write(element + " ");
                }
            });

            Task.WaitAll(task1, task2, task3);
            Console.ReadLine();
        }
    }
}
