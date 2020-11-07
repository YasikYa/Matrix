using MatrixLab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTest
    {
        private readonly double[,] _array = new double[,] { { 5, -3, 2 }, { 1, 7, 6 }, { -4, 2, -6 } };
        private double[,] Array => (double[,])_array.Clone();
        private Matrix _matrix;

        [TestInitialize]
        public void Init()
        {
            _matrix = new Matrix(Array);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _matrix = null;
        }

        [TestMethod]
        public void TransposedMatrixShouldHasCorrectValues()
        {
            _matrix.Transponse();

            VerifyMatrixValues((r, c) => _array[c, r]);
        }

        [TestMethod]
        public void MatrixCanAddMatrix()
        {
            _matrix.Add(new Matrix(Array));

            VerifyMatrixValues((r, c) => _array[r, c] + _array[r, c]);
        }

        [TestMethod]
        public void MatrixCanMultiplyByValue()
        {
            var multiplier = 2;
            _matrix.MultiplyBy(multiplier);

            VerifyMatrixValues((r, c) => _array[r, c] * multiplier);
        }

        [TestMethod]
        public void MatrixCanMultiplyByMatrix()
        {
            var result = new Matrix(Array).MultiplyBy(_matrix);

            Assert.AreEqual(14, result[0, 0]);
            Assert.AreEqual(-32, result[0, 1]);
            Assert.AreEqual(-20, result[0, 2]);
            Assert.AreEqual(-12, result[1, 0]);
            Assert.AreEqual(58, result[1, 1]);
            Assert.AreEqual(8, result[1, 2]);
            Assert.AreEqual(6, result[2, 0]);
            Assert.AreEqual(14, result[2, 1]);
            Assert.AreEqual(40, result[2, 2]);
        }

        [TestMethod]
        public void MatrixCanCalcDeterminator()
        {
            Assert.AreEqual(-156, _matrix.Det);
        }
        private void VerifyMatrixValues(Func<int, int, double> expect)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Assert.AreEqual(expect(row, col), _matrix[row, col], $"Matrix has incorrect value at index [{row}, {col}]");
                }
            }
        }
    }
}
