using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;

namespace MatrixLab1
{
    public class Matrix
    {

        private readonly double[,] _matrix;

        public double Det => CalcDeterminator();

        public Matrix()
        {
            var rnd = new Random();
            var matrix = new double[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    var value = -5 + (rnd.NextDouble() * (10));
                    matrix[row, col] = Math.Round(value, 2);
                }
            }
            _matrix = matrix;
        }

        public Matrix(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1) && matrix.GetLength(0) != 3)
                throw new Exception("Invalid matrix size");

            _matrix = matrix;
        }

        public void Add(Matrix addFrom)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    _matrix[row, col] = _matrix[row, col] + addFrom[row, col];
                }
            }
        }

        public Matrix MultiplyBy(Matrix multiplier)
        {
            var resultMatrix = new double[3, 3];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    double aggregate = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        aggregate += _matrix[row, i] * multiplier[i, col];
                    }

                    resultMatrix[row, col] = Math.Round(aggregate, 2);
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
                    _matrix[row, col] = Math.Round(_matrix[row, col] * value, 2);
                }
            }
        }

        public void Transponse()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (col <= row)
                        continue;

                    var temp = _matrix[row, col];
                    _matrix[row, col] = _matrix[col, row];
                    _matrix[col, row] = temp;
                }
            }
        }

        private double CalcDeterminator()
        {
            return _matrix[0, 0] * _matrix[1, 1] * _matrix[2, 2] +
                _matrix[2, 0] * _matrix[0, 1] * _matrix[1, 2] +
                _matrix[1, 0] * _matrix[2, 1] * _matrix[0, 2] -
                _matrix[2, 0] * _matrix[1, 1] * _matrix[0, 2] -
                _matrix[0, 0] * _matrix[2, 1] * _matrix[1, 2] -
                _matrix[1, 0] * _matrix[0, 1] * _matrix[2, 2];
        }

        public void Display()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write($"{_matrix[row, col]}\t");
                }

                Console.WriteLine();
            }
        }

        public double this[int row, int col] => _matrix[row, col];
    }
}
