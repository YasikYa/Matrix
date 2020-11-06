﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLab1
{
    class MatrixAccessor : IMatrixAccessor
    {
        private double[,] _matrix;
        private bool _transposed = false;

        public int Size => _matrix.GetLength(0);

        public MatrixAccessor(double[,] matrix) => _matrix = matrix;

        public void Transpose() => _transposed = !_transposed;

        public double this[int row, int col]
        { 
            get
            {
                var transformedIndexes = TransformIndexes(row, col);
                return _matrix[transformedIndexes.row, transformedIndexes.col];
            }

            set
            {
                var transformedIndexes = TransformIndexes(row, col);
                _matrix[transformedIndexes.row, transformedIndexes.col] = value;
            }
        }

        private (int row, int col) TransformIndexes(int row, int col) => _transposed ? (col, row) : (row, col);
    }
}
