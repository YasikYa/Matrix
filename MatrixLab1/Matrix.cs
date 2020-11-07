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

        private readonly MatrixAccessor _accessor;

        public double Det => Rows == Columns ? CalcDeterminator(_accessor) : throw new Exception("Determinator can be calculated only for the NxN matrix");
        public int Rows => _accessor.Rows;
        public int Columns => _accessor.Columns;

        public Matrix(int rowCount, int colCount)
        {
            var rnd = new Random();
            var matrix = new double[rowCount, colCount];
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    var value = Min + (rnd.NextDouble() * (Max - Min));
                    matrix[row, col] = Math.Round(value, 2);
                }
            }
            _accessor = new MatrixAccessor(matrix);
        }

        public Matrix(double[,] matrix)
        {
            _accessor = new MatrixAccessor(matrix);
        }

        public Matrix(MatrixAccessor accessor) => _accessor = accessor;

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
            if (_accessor.Columns != multiplier.Rows)
                throw new Exception("Cannot multiply matrix. Columns count differs from rows count between multipliers");

            var resultMatrix = new double[_accessor.Rows, multiplier.Columns];
            for (int row = 0; row < _accessor.Rows; row++)
            {
                for (int col = 0; col < multiplier.Columns; col++)
                {
                    double aggregate = 0;
                    for (int i = 0; i < _accessor.Columns; i++)
                    {
                        aggregate += _accessor[row, i] * multiplier[i, col];
                    }

                    resultMatrix[row, col] = Math.Round(aggregate, 2);
                }
            }

            return new Matrix(resultMatrix);
        }

        public void MultiplyBy(double value)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    _accessor[row, col] = Math.Round(_accessor[row, col] * value, 2);
                }
            }
        }

        public void Transponse()
        {
            _accessor.Transpose();
        }

        private double CalcDeterminator(IMatrixAccessor accessor)
        {
            if (accessor.Rows == 2)
            {
                return accessor[0, 0] * accessor[1, 1] - accessor[1, 0] * accessor[0, 1];
            }

            double determinator = 0;
            for (int i = 0; i < accessor.Columns; i++)
            {
                double minorDeterminator = IsPositiveSign(accessor.Rows, i)
                    ? CalcDeterminator(new DeterminatorAccessor(i, accessor))
                    : CalcDeterminator(new DeterminatorAccessor(i, accessor)) * -1;

                determinator += accessor[0, i] * minorDeterminator;
            }

            return determinator;
        }

        private bool IsPositiveSign(int decomposedSize, int col)
        {
            var sizeDiff = _accessor.Rows - decomposedSize;
            var angleLength = sizeDiff * 2 + col;
            return (angleLength % 2) == 0;
        }

        public void Display()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Console.Write($"{_accessor[row, col]}\t");
                }

                Console.WriteLine();
            }
        }

        public double this[int row, int col] => _accessor[row, col];
    }
}
