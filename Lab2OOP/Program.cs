using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = "1 2 3 \n 4 5 6 \n 7 8 9";
            MyMatrix firstmatrix = new MyMatrix(line);
            Console.WriteLine("First matrix: ");
            Console.WriteLine(firstmatrix);
            MyMatrix secondmatrix = new MyMatrix(new double[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 5, 6, 7 } });
            Console.WriteLine("Second matrix: ");
            Console.WriteLine(secondmatrix);
            MyMatrix resultMatrixAdd = firstmatrix + secondmatrix;
            Console.WriteLine("Result of Matrix Addition:");
            Console.WriteLine(resultMatrixAdd);
            MyMatrix resultMatrixMult = firstmatrix * secondmatrix;
            Console.WriteLine("Result of Matrix Mult:");
            Console.WriteLine(resultMatrixMult);

            MyMatrix transposedMatrix = firstmatrix.GetTransponedCopy();
            Console.WriteLine("Result of transponed matrix");
            Console.WriteLine(transposedMatrix);

            firstmatrix.TransponeMe();
            Console.WriteLine("Result of TransponeMe matrix");
            Console.WriteLine(firstmatrix);
            Console.ReadLine();
        }
    }
}
