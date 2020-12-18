using Matrix_Math.Models;
using Xunit;

namespace Matrix_Test
{
    public class Matrix3x2and2x3
    {
        private Matrix a = new Matrix(3, 2);
        private Matrix b = new Matrix(2, 3);

        public Matrix3x2and2x3()
        {
            a[0, 0] = 1; a[0, 1] = 2;
            a[1, 0] = 3; a[1, 1] = 4;
            a[2, 0] = 5; a[2, 1] = 6;

            b[0, 0] = 1; b[0, 1] = 2; b[0, 2] = 3;
            b[1, 0] = 4; b[1, 1] = 5; b[1, 2] = 6;
        }
        [Fact]
        public void Mul()
        {
            var result = a * b;

            var e = new Matrix(3, 3);
            e[0, 0] = 9; e[0, 1] = 12; e[0, 2] = 15;
            e[1, 0] = 19; e[1, 1] = 26; e[1, 2] = 33;
            e[2, 0] = 29; e[2, 1] = 40; e[2, 2] = 51;

            Assert.Equal(e, result);
        }
        [Fact]
        public void Transpose()
        {
            var result = a.Transpose();

            var e = new Matrix(2, 3);
            e[0, 0] = 1; e[0, 1] = 3; e[0, 2] = 5;
            e[1, 0] = 2; e[1, 1] = 4; e[1, 2] = 6;

            Assert.Equal(e, result);
        }
        [Fact]
        public void InverseMatrix()
        {
            var result = a.InverseMatrix();

            var e = new Matrix(3, 3);
            e[0, 0] = 0; e[0, 1] = 0; e[0, 2] = 0.2;
            e[1, 0] = 0.1; e[1, 1] = 0.3; e[1, 2] = -0.02;
            e[2, 0] = 0.4; e[2, 1] = 0.2; e[2, 2] = -0.08;

            Assert.Equal(e, result);
        }
    }
}
