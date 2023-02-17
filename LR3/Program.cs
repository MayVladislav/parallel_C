using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LR3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = GetRandomMatrix(3, 3);
            int[,] matrix2 = GetRandomMatrix(3, 3);

            AsyncCallback callback = new AsyncCallback(SumCallback);
            SumDelegate sumDelegate = new SumDelegate(SumMatrices);
            IAsyncResult result = sumDelegate.BeginInvoke(matrix1, matrix2, callback, null);
            Console.WriteLine("Calculating sum of matrices...");

            // Wait for the result
            while (!result.IsCompleted)
            {
                Console.WriteLine("Waiting for result...");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Sum of matrices:");
            PrintMatrix(sumDelegate.EndInvoke(result));
            Console.ReadKey();
        }

        private static int[,] GetRandomMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(10);
                }
            }
            return matrix;
        }

        private delegate int[,] SumDelegate(int[,] matrix1, int[,] matrix2);

        private static int[,] SumMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int columns = matrix1.GetLength(1);
            int[,] sum = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sum[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return sum;
        }

        private static void SumCallback(IAsyncResult result)
        {
            Console.WriteLine("Sum completed.");
        }

        private static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
