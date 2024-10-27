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
            MyMatrix myMatrix = new MyMatrix(line);
        }
    }
}
