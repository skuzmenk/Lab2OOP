using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OOP
{
    public partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
            {
                throw new ArgumentException("Matrix must have the same sizes.");
            }
            double[,] result = new double[a.Height, a.Width];
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < a.Width; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return new MyMatrix(result);
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Width != b.Height)
            {
                throw new ArgumentException("The number of columns of the first matrix must be equal to the number of rows of the second.");
            }
            double[,] result = new double[a.Height, b.Width];
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    for (int k = 0; k < a.Width; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return new MyMatrix(result);
        }
        private double[,] GetTransposedArray()
        {
            double[,] transposed = new double[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }
            return transposed;
        }
    }
}
