using System;

namespace MatrixLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix.Min = -10;
            Matrix.Max = 10;

            var matrix = new Matrix();
            matrix.Display();

            Console.WriteLine();
            Console.WriteLine(matrix.Det);

            matrix.Transponse();

            Console.WriteLine();
            matrix.Display();

            Console.WriteLine();
            Console.WriteLine(matrix.Det);

            var mult = matrix.MultiplyBy(new Matrix());
            mult.Display();

            Console.ReadLine();
        }
    }
}
