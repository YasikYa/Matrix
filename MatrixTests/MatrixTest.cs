using MatrixLab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MatrixTests
{
    [TestClass]
    public class MatrixTest
    {
        private readonly double[,] _squareArray = new double[,] { { 5, -3, 2 }, { 1, 7, 6 }, { -4, 2, -6 } };
        private readonly double[,] _array = new double[,] { { 2, 5 }, { -1, 3 }, { -4, 4 } };
        private double[,] Array => (double[,])_array.Clone();
        private double[,] SquareArray => (double[,])_squareArray.Clone();

        private Matrix _squareMatrix;
        private Matrix _matrix;

        [TestInitialize]
        public void Init()
        {
            _squareMatrix = new Matrix(SquareArray);
            _matrix = new Matrix(Array);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _squareMatrix = null;
            _matrix = null;
        }

        [TestMethod]
        public void MatrixShouldHasCorrectSize()
        {
            var dynamicMatrix = new Matrix(5, 2);

            Assert.AreEqual(3, _squareMatrix.Rows, "Array initialized matrix has incorrect rows count");
            Assert.AreEqual(3, _squareMatrix.Columns, "Array initialized matrix has incorrect columns count");
            Assert.AreEqual(5, dynamicMatrix.Rows, "Dynamic initialized matrix has incorrect rows count");
            Assert.AreEqual(2, dynamicMatrix.Columns, "Dynamic initialized matrix has incorrect columns count");
        }

        [TestMethod]
        public void TransposedMatrixShouldHasCorrectSize()
        {
            _matrix.Transponse();

            Assert.AreEqual(2, _matrix.Rows, "Unexpected rows count in transposed matrix");
            Assert.AreEqual(3, _matrix.Columns, "Unexpected columns count in transposed matrix");
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
        public void MatrixMultShouldResultInCorrectSize()
        {
            var result = _matrix.MultiplyBy(new Matrix(2, 3));

            Assert.AreEqual(3, result.Rows, "Mult result matrix has incorrect rows count");
            Assert.AreEqual(3, result.Columns, "Mult result matrix has incorrect columns count");
        }

        [TestMethod]
        public void MatrixCanMultiplyByMatrix()
        {
            var multiplierArray = new double[,] { { -4, 1, 5 }, { 3, 2, -3 } };
            var result = new Matrix(multiplierArray).MultiplyBy(_matrix);

            Assert.AreEqual(-29, result[0, 0]);
            Assert.AreEqual(3, result[0, 1]);
            Assert.AreEqual(16, result[1, 0]);
            Assert.AreEqual(9, result[1, 1]);
        }

        [TestMethod]
        public void MatrixCanCalcDeterminator()
        {
            Assert.AreEqual(-156, _squareMatrix.Det);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CanNotCalcDeterminatorOnNotSquareMatrix()
        {
            _ = _matrix.Det;
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CanNotAddMatrixOfDifferentSize()
        {
            _matrix.Add(_squareMatrix);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CanNotMultInappropriateMatrix()
        {
            _ = _matrix.MultiplyBy(_squareMatrix);
        }

        private void VerifyMatrixValues(Func<int, int, double> expect)
        {
            for (int row = 0; row < _matrix.Rows; row++)
            {
                for (int col = 0; col < _matrix.Columns; col++)
                {
                    var actual = _matrix[row, col];
                    var expected = expect(row, col);
                    Assert.AreEqual(expected, actual, $"Matrix has incorrect value at index [{row}, {col}]");
                }
            }
        }
    }
}
