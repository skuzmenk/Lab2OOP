using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2OOP
{
    public class MyMatrix
    {
        protected double[,] matrix;

        public MyMatrix(MyMatrix other)
        {
            int height = other.matrix.GetLength(0);
            int width = other.matrix.GetLength(1);
            matrix = new double[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = other.matrix[i, j]; 
                }
            }
        }
        public MyMatrix(double[,] matrix)
        {
            this.matrix = matrix;
        }
        public MyMatrix(double[][] jaggedArray)
        {
            int rowCount = jaggedArray.Length;
            if (rowCount == 0)
                throw new ArgumentException("Jagged array cannot be empty");
            int colCount = jaggedArray[0].Length;
            for (int i = 1; i < rowCount; i++)
            {
                if (jaggedArray[i].Length != colCount)
                {
                    throw new ArgumentException("Jagged array is not rectangular.");
                }
            }
            matrix = new double[rowCount, colCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = jaggedArray[i][j];
                }
            }
        }
        public MyMatrix(string matrixString)
        {
            string[] rows = matrixString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Length == 0)
                throw new ArgumentException("Matrix cannot be empty.");

            int colCount = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            matrix = new double[rows.Length, colCount];

            for (int i = 0; i < rows.Length; i++)
            {
                string[] elementsString = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (elementsString.Length != colCount)
                    throw new ArgumentException("Matrix is not rectangular.");

                for (int j = 0; j < colCount; j++)
                    matrix[i, j] = double.Parse(elementsString[j]);
            }
        }
        public int Height
        {
            get
            {
                return matrix.GetLength(0); 
            }
        }
        public int Width
        {
            get 
            { 
                return matrix.GetLength(1);
            }
        }
        // Java-style getter
        public int getHeight()
        {
            return Height;
        }
        public int getWidth()
        {
            return Width;
        }
        // Індексатор для доступу до елементів матриці
        public double this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= Height || col < 0 || col >= Width)
                    throw new IndexOutOfRangeException("Індекс виходить за межі матриці.");
                return matrix[row, col];
            }
            set
            {
                if (row < 0 || row >= Height || col < 0 || col >= Width)
                    throw new IndexOutOfRangeException("Індекс виходить за межі матриці.");
                matrix[row, col] = value;
            }
        }
        override public String ToString()
        {
            string result = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result += matrix[i, j] + "\t"; 
                }
                result += Environment.NewLine; 
            }
            return result;
        }

    }
}
