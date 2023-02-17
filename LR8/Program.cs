using System;
using System.Threading.Tasks;

namespace MatrixSumExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = GenerateRandomMatrix(3, 3);
            int[,] matrix2 = GenerateRandomMatrix(3, 3);

            Console.WriteLine("Matrix 1:");
            PrintMatrix(matrix1);

            Console.WriteLine("Matrix 2:");
            PrintMatrix(matrix2);

            int[,] sum = CalculateMatrixSum(matrix1, matrix2);

            Console.WriteLine("Sum of the matrices:");
            PrintMatrix(sum);

            Console.ReadLine();
        }

        private static int[,] CalculateMatrixSum(int[,] matrix1, int[,] matrix2)
        {
            int[,] sum = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            Task[] tasks = new Task[matrix1.GetLength(0)];

            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                int row = i;
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < matrix1.GetLength(1); j++)
                    {
                        sum[row, j] = matrix1[row, j] + matrix2[row, j];
                    }
                });
            }

            Task.WaitAll(tasks);

            return sum;
        }

        private static int[,] GenerateRandomMatrix(int rows, int columns)
        {
            int[,] matrix = new int[rows, columns];
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rnd.Next(1, 10);
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}