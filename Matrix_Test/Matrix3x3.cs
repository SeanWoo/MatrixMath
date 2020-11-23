using Matrix_Math.Models;
using System;
using Xunit;

namespace Matrix_Test
{
    public class Matrix3x3
    {
        private Matrix a = new Matrix(3, 3);
        private Matrix b = new Matrix(3, 3);
        private Random rnd = new Random();

        public Matrix3x3()
        {
            a[0, 0] = 1; a[0, 1] = 2; a[0, 2] = 3;
            a[1, 0] = 4; a[1, 1] = 5; a[1, 2] = 6;
            a[2, 0] = 7; a[2, 1] = 8; a[2, 2] = 9;

            b[0, 0] = 1; b[0, 1] = 2; b[0, 2] = 3;
            b[1, 0] = 4; b[1, 1] = 5; b[1, 2] = 6;
            b[2, 0] = 7; b[2, 1] = 8; b[2, 2] = 9;
        }

        [Fact]
        public void Add()
        {
            var result = a + b;

            var e = new Matrix(3, 3);
            e[0, 0] = 2; e[0, 1] = 4; e[0, 2] = 6;
            e[1, 0] = 8; e[1, 1] = 10; e[1, 2] = 12;
            e[2, 0] = 14; e[2, 1] = 16; e[2, 2] = 18;


            Assert.Equal(e, result);
        }
        [Fact]
        public void Sub()
        {
            var result = a - b;

            var e = new Matrix(3, 3);
            e[0, 0] = 0; e[0, 1] = 0; e[0, 2] = 0;
            e[1, 0] = 0; e[1, 1] = 0; e[1, 2] = 0;
            e[2, 0] = 0; e[2, 1] = 0; e[2, 2] = 0;

            Assert.Equal(e, result);
        }
        [Fact]
        public void Mul()
        {
            var result = a * b;

            var e = new Matrix(3, 3);
            e[0, 0] = 30; e[0, 1] = 36; e[0, 2] = 42;
            e[1, 0] = 66; e[1, 1] = 81; e[1, 2] = 96;
            e[2, 0] = 102; e[2, 1] = 126; e[2, 2] = 150;

            Assert.Equal(e, result);
        }
        [Fact]
        public void AddNumber()
        {
            double number = Math.Round(rnd.NextDouble() * 100, 2);
            var result = a + number;

            var e = new Matrix(3, 3);
            e[0, 0] = a[0, 0] + number; e[0, 1] = a[0, 1] + number; e[0, 2] = a[0, 2] + number;
            e[1, 0] = a[1, 0] + number; e[1, 1] = a[1, 1] + number; e[1, 2] = a[1, 2] + number;
            e[2, 0] = a[2, 0] + number; e[2, 1] = a[2, 1] + number; e[2, 2] = a[2, 2] + number;

            Assert.Equal(e, result);
        }
        [Fact]
        public void SubNumber()
        {
            double number = Math.Round(rnd.NextDouble() * 100, 2);
            var result = a - number;

            var e = new Matrix(3, 3);
            e[0, 0] = a[0, 0] - number; e[0, 1] = a[0, 1] - number; e[0, 2] = a[0, 2] - number;
            e[1, 0] = a[1, 0] - number; e[1, 1] = a[1, 1] - number; e[1, 2] = a[1, 2] - number;
            e[2, 0] = a[2, 0] - number; e[2, 1] = a[2, 1] - number; e[2, 2] = a[2, 2] - number;

            Assert.Equal(e, result);
        }
        [Fact]
        public void MulNumber()
        {
            double number = Math.Round(rnd.NextDouble() * 100, 2);
            var result = a * number;

            var e = new Matrix(3, 3);
            e[0, 0] = a[0, 0] * number; e[0, 1] = a[0, 1] * number; e[0, 2] = a[0, 2] * number;
            e[1, 0] = a[1, 0] * number; e[1, 1] = a[1, 1] * number; e[1, 2] = a[1, 2] * number;
            e[2, 0] = a[2, 0] * number; e[2, 1] = a[2, 1] * number; e[2, 2] = a[2, 2] * number;

            Assert.Equal(e, result);
        }
        [Fact]
        public void Determinant()
        {
            var result = a.Determinant();

            Assert.Equal(0.0, result);
        }
    }
}
