using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLab1
{
    public class MatrixAccessor : IMatrixAccessor
    {
        private double[,] _matrix;
        private bool _transposed = false;

        public int Rows => throw new NotImplementedException();

        public int Columns => throw new NotImplementedException();

        public MatrixAccessor(double[,] matrix) => throw new NotImplementedException();

        public void Transpose() => throw new NotImplementedException();

        public double this[int row, int col]
        { 
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private (int row, int col) TransformIndexes(int row, int col) => throw new NotImplementedException();
    }
}
