using System;
using System.Threading;

namespace MatrixSumExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matrix2 = new int[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };
            int[,] result = new int[3, 3];

            // Creating a background thread
            Thread bgThread = new Thread(() => MatrixSum(matrix1, matrix2, result));
            bgThread.IsBackground = true;
            bgThread.Start();

            // Creating a foreground thread with higher priority
            Thread fgThread = new Thread(() => MatrixSum(matrix1, matrix2, result));
            fgThread.Priority = ThreadPriority.Highest;
            fgThread.Start();

            // Wait for the foreground thread to complete
            fgThread.Join();

            Console.WriteLine("The sum of two matrices is: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void MatrixSum(int[,] matrix1, int[,] matrix2, int[,] result)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                    Thread.Sleep(100);
                }
            }
        }
    }
}