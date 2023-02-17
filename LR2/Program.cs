using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matrix2 = new int[3, 3] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } };
            int[,] resultMatrix = MatrixSum(matrix1, matrix2, (x, y) => x + y);

            Console.WriteLine("Result matrix:");
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                {
                    Console.Write(resultMatrix[i, j] + " ");
                }
                Console.WriteLine();

            }
        }

        static int[,] MatrixSum(int[,] matrix1, int[,] matrix2, Func<int, int, int> sumFunction)
        {
            int rows = matrix1.GetLength(0);
            int columns = matrix1.GetLength(1);
            int[,] resultMatrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    resultMatrix[i, j] = sumFunction(matrix1[i, j], matrix2[i, j]);
                }
            }
            return resultMatrix;
        }
    }
}
