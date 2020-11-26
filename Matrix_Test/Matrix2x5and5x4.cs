using Matrix_Math.Models;
using Xunit;

namespace Matrix_Test
{
    public class Matrix2x5and5x4
    {
        private Matrix a = new Matrix(2, 5);
        private Matrix b = new Matrix(5, 4);

        public Matrix2x5and5x4()
        {
            a[0, 0] = 1; a[0, 1] = 2; a[0, 2] = 3; a[0, 3] = 4; a[0, 4] = 5;
            a[1, 0] = 6; a[1, 1] = 7; a[1, 2] = 8; a[1, 3] = 9; a[1, 4] = 10;

            b[0, 0] = 1; b[0, 1] = 2; b[0, 2] = 3; b[0, 3] = 4;
            b[1, 0] = 2; b[1, 1] = 3; b[1, 2] = 4; b[1, 3] = 5;
            b[2, 0] = 3; b[2, 1] = 4; b[2, 2] = 5; b[2, 3] = 6;
            b[3, 0] = 6; b[3, 1] = 7; b[3, 2] = 7; b[3, 3] = 7;
            b[4, 0] = 8; b[4, 1] = 9; b[4, 2] = 9; b[4, 3] = 9;
        }
        [Fact]
        public void Mul()
        {
            var result = a * b;

            var e = new Matrix(2, 4);
            e[0, 0] = 78; e[0, 1] = 93; e[0, 2] = 99; e[0, 3] = 105;
            e[1, 0] = 178; e[1, 1] = 218; e[1, 2] = 239; e[1, 3] = 260;

            Assert.Equal(e, result);
        }
    }
}