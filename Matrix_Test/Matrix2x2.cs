using Xunit;
using Matrix_Math.Models;
using System;

namespace Matrix_Test
{
    public class Matrix2x2
    {
        private Matrix a = new Matrix(2, 2);
        private Matrix b = new Matrix(2, 2);
        private Random rnd = new Random();

        public Matrix2x2()
        {
            a[0, 0] = 1; a[0, 1] = 2;
            a[1, 0] = 3; a[1, 1] = 4;

            b[0, 0] = 1; b[0, 1] = 2;
            b[1, 0] = 3; b[1, 1] = 4;
        }

        [Fact]
        public void Add()
        {
            var result = a + b;

            var e = new Matrix(2, 2);
            e[0, 0] = 2; e[0, 1] = 4;
            e[1, 0] = 6; e[1, 1] = 8;

            Assert.Equal(e, result);
        }
        [Fact]
        public void Sub()
        {
            var result = a - b;

            var e = new Matrix(2, 2);
            e[0, 0] = 0; e[0, 1] = 0;
            e[1, 0] = 0; e[1, 1] = 0;

            Assert.Equal(e, result);
        }
        [Fact]
        public void Mul()
        {
            var result = a * b;

            var e = new Matrix(2, 2);
            e[0, 0] = 7; e[0, 1] = 10;
            e[1, 0] = 15; e[1, 1] = 22;

            Assert.Equal(e, result);
        }
        [Fact]
        public void AddNumber()
        {
            double number = Math.Round(rnd.NextDouble() * 100, 2);
            var result = a + number;

            var e = new Matrix(2, 2);
            e[0, 0] = a[0, 0] + number; e[0, 1] = a[0, 1] + number;
            e[1, 0] = a[1, 0] + number; e[1, 1] = a[1, 1] + number;

            Assert.Equal(e, result);
        }
        [Fact]
        public void SubNumber()
        {
            double number = Math.Round(rnd.NextDouble() * 100, 2);
            var result = a - number;

            var e = new Matrix(2, 2);
            e[0, 0] = a[0, 0] - number; e[0, 1] = a[0, 1] - number;
            e[1, 0] = a[1, 0] - number; e[1, 1] = a[1, 1] - number;

            Assert.Equal(e, result);
        }
        [Fact]
        public void MulNumber()
        {
            double number = Math.Round(rnd.NextDouble() * 100, 2);
            var result = a * number;

            var e = new Matrix(2, 2);
            e[0, 0] = a[0, 0] * number; e[0, 1] = a[0, 1] * number;
            e[1, 0] = a[1, 0] * number; e[1, 1] = a[1, 1] * number;

            Assert.Equal(e, result);
        }
        [Fact]
        public void Determinant()
        {
            var result = a.Determinant();

            Assert.Equal(-2.0, result);
        }
    }
}
