using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace MatrixLab1
{
    public class Matrix
    {
        public static double Min { get; set; }
        public static double Max { get; set; }

        private readonly MatrixAccessor _accessor;

        public double Det => throw new NotImplementedException();
        public int Rows => throw new NotImplementedException();
        public int Columns => throw new NotImplementedException();

        public Matrix(int rowCount, int colCount) => throw new NotImplementedException();

        public Matrix(double[,] matrix) => throw new NotImplementedException();

        public Matrix(MatrixAccessor accessor) => throw new NotImplementedException();

        public void Add(Matrix addFrom) => throw new NotImplementedException();

        public Matrix MultiplyBy(Matrix multiplier) => throw new NotImplementedException();

        public void MultiplyBy(double value) => throw new NotImplementedException();

        public void Transponse() => throw new NotImplementedException();

        private double CalcDeterminator(IMatrixAccessor accessor) => throw new NotImplementedException();

        public void Display() => throw new NotImplementedException();

        public double this[int row, int col] => throw new NotImplementedException();
    }
}
