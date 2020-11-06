using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLab1
{
    class DeterminatorAccessor : IMatrixAccessor
    {
        public int Size => _mainAccessor.Size - 1;
        private IMatrixAccessor _mainAccessor;
        private int _col;

        public DeterminatorAccessor(int col, IMatrixAccessor mainAccessor) => (_col, _mainAccessor) = (col, mainAccessor);

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
            var colIndex = col >= _col ? col + 1 : col;

            return (rowIndex, colIndex);
        }
    }
}
