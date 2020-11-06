using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixLab1
{
    interface IMatrixAccessor
    {
        int Size { get; }

        double this[int row, int col]
        {
            get;
            set;
        }
    }
}
