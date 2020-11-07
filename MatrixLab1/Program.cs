using System;

namespace MatrixLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new double[,] { { 5, -3, 2 }, { 1, 7, 6 }, { -4, 2, -6 } };
            Matrix.Min = -5;
            Matrix.Max = 5;

            var matrix = new Matrix(arr);
            matrix.Display();
            matrix.Transponse();
            Console.WriteLine("Transposed");
            matrix.Display();
            Console.WriteLine("Transposed back");
            matrix.Transponse();
            matrix.Display();
            Console.WriteLine("Determinator");
            Console.WriteLine(matrix.Det);
            Console.WriteLine("Multiplier");
            var multiplier = new Matrix(3, 2);
            multiplier.Display();
            Console.WriteLine("Mult result");
            var result = matrix.MultiplyBy(multiplier);
            result.Display();
            Console.WriteLine("Mult result by 2");
            result.MultiplyBy(2);
            result.Display();
            Console.ReadLine();
        }
    }
}
