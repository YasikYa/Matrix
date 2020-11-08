using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLab1
{
    class DeterminatorAccessor : IMatrixAccessor
    {
        private IMatrixAccessor _mainAccessor;
        private int _decomposingCol;

        // Decrease virtual matrix size by 1 on each decompose step
        public int Rows => throw new NotImplementedException();

        // Determinator can be calculated only for NxN matrix, rows == columns here.
        public int Columns => throw new NotImplementedException();

        public DeterminatorAccessor(int decomposingCol, IMatrixAccessor mainAccessor) => throw new NotImplementedException();

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
