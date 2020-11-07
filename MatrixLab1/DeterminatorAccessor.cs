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
        public int Rows => _mainAccessor.Rows - 1;

        // Determinator can be calculated only for NxN matrix, rows == columns here.
        public int Columns => Rows;

        public DeterminatorAccessor(int decomposingCol, IMatrixAccessor mainAccessor) => (_decomposingCol, _mainAccessor) = (decomposingCol, mainAccessor);

        public double this[int row, int col]
        {
            get
            {
                var transformedIndexes = TransformIndexes(row, col);
                return _mainAccessor[transformedIndexes.row, transformedIndexes.col];
            }

            set
            {
                var transformedIndexes = TransformIndexes(row, col);
                _mainAccessor[transformedIndexes.row, transformedIndexes.col] = value;
            }
        }

        private (int row, int col) TransformIndexes(int row, int col)
        {
            var rowIndex = row + 1;
            var colIndex = col >= _decomposingCol ? col + 1 : col;

            return (rowIndex, colIndex);
        }
    }
}
