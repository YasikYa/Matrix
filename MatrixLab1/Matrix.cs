using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace MatrixLab1
{
    class Matrix
    {
        public static double Min { get; set; }

        public static double Max { get; set; }

        private MatrixAccessor _accessor;

        public double Det => CalcDeterminator(_accessor);

        public Matrix()
        {
            //var rnd = new Random();
            //_matrix = new double[3, 3];
            //for (int row = 0; row < 3; row++)
            //{
            //    for (int col = 0; col < 3; col++)
            //    {
            //        var value = Min + (rnd.NextDouble() * (Max - Min));
            //        _matrix[row, col] = Math.Round(value, 2);
            //    }
            //}
            _accessor = new MatrixAccessor(new double[,] { { 5, -3, 2 }, { 1, 7, 6 }, { -4, 2, -6 } });
        }

        public Matrix(double[,] matrix)
        {
            _accessor = new MatrixAccessor(matrix);
        }

        public void Add(Matrix addFrom)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    _accessor[row, col] = _accessor[row, col] + addFrom[row, col];
                }
            }
        }

        public Matrix MultiplyBy(Matrix multiplier)
        {
            var resultMatrix = new double[3, 3];
            for (int row = 0; row < _accessor.Size; row++)
            {
                for (int col = 0; col < _accessor.Size; col++)
                {
                    double aggregate = 0;
                    for (int i = 0; i < _accessor.Size; i++)
                    {
                        aggregate += _accessor[row, i] * multiplier[i, col];
                    }

                    resultMatrix[row, col] = aggregate;
                }
            }

            return new Matrix(resultMatrix);
        }

        public void MultiplyBy(double value)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    _accessor[row, col] = _accessor[row, col] * value;
                }
            }
        }

        public void Transponse()
        {
            _accessor.Transpose();
        }

        private double CalcDeterminator(IMatrixAccessor accessor)
        {
            if (accessor.Size == 2)
            {
                return accessor[0, 0] * accessor[1, 1] - accessor[1, 0] * accessor[0, 1];
            }

            double determinator = 0;
            for (int i = 0; i < accessor.Size; i++)
            {
                double minorDeterminator = IsPositiveSign(accessor.Size, i)
                    ? CalcDeterminator(new DeterminatorAccessor(i, accessor))
                    : CalcDeterminator(new DeterminatorAccessor(i, accessor)) * -1;

                determinator += accessor[0, i] * minorDeterminator;
            }

            return determinator;
        }

        private bool IsPositiveSign(int size, int col)
        {
            var sizeDiff = _accessor.Size - size;
            var stepsRequired = sizeDiff * 2 + col;
            return (stepsRequired % 2) == 0;
        }

        public void Display()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{_accessor[row, col]}\t");
                }

                Console.WriteLine();
            }
        }

        public double this[int row, int col] => _accessor[row, col];
    }
}
