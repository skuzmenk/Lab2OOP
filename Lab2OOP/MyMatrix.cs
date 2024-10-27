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
            matrix = (double[,])other.matrix.Clone();
        }
       
        public int Height
        {
            get { return matrix.GetLength(0); }
        }
        public int Width
        {
            get { return matrix.GetLength(1); }
        }

    }
}
