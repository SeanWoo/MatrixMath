using Matrix_Math.Models;
using Xunit;

namespace Matrix_Test
{
    public class Matrix2x5and5x2
    {
        private Matrix a = new Matrix(2, 5);
        private Matrix b = new Matrix(5, 2);

        public Matrix2x5and5x2()
        {
            a[0, 0] = 1; a[0, 1] = 2; a[0, 2] = 3; a[0, 3] = 4; a[0, 4] = 5;
            a[1, 0] = 6; a[1, 1] = 7; a[1, 2] = 8; a[1, 3] = 9; a[1, 4] = 10;

            b[0, 0] = 1; b[0, 1] = 2;
            b[1, 0] = 3; b[1, 1] = 4;
            b[2, 0] = 5; b[2, 1] = 6;
            b[3, 0] = 7; b[3, 1] = 8;
            b[4, 0] = 9; b[4, 1] = 10;
        }
        [Fact]
        public void Mul()
        {
            var result = a * b;

            var e = new Matrix(2, 2);
            e[0, 0] = 95; e[0, 1] = 110;
            e[1, 0] = 220; e[1, 1] = 260;

            Assert.Equal(e, result);
        }
    }
}
