using System;
using System.Threading;

namespace MatrixTransformExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            Random random = new Random();

            // Initialize matrix with random numbers
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(1, 100);
                }
            }

            Console.WriteLine("Original Matrix:");
            PrintMatrix(matrix);

            // Delegate for transforming matrix elements
            Action<int, int> transformMatrix = (i, j) =>
            {
                if (matrix[i, j] % 2 == 0)
                {
                    matrix[i, j] = (int)(Math.Cos(matrix[i, j]) + Math.Sin(matrix[i, j]));
                }
            };

            // Use multiple threads to transform the matrix
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int x = i;
                    int y = j;
                    Thread thread = new Thread(() => transformMatrix(x, y));
                    thread.Start();
                }
            }

            Console.WriteLine("Transformed Matrix:");
            PrintMatrix(matrix);

            Console.ReadLine();
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}