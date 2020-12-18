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
            a[0, 0] = 1; a[0, 1] = -2; a[0, 2] = 3;
            a[1, 0] = 0; a[1, 1] = 4; a[1, 2] = -1;
            a[2, 0] = 5; a[2, 1] = 0; a[2, 2] = 0;

            b[0, 0] = 1; b[0, 1] = 2; b[0, 2] = 3;
            b[1, 0] = 4; b[1, 1] = 5; b[1, 2] = 6;
            b[2, 0] = 7; b[2, 1] = 8; b[2, 2] = 9;
        }

        [Fact]
        public void Add()
        {
            var result = a + b;

            var e = new Matrix(3, 3);
            for (int x = 0; x < e.SizeX; x++)
                for (int y = 0; y < e.SizeY; y++)
                    e[x, y] = a[x, y] + b[x, y];

            Assert.Equal(e, result);
        }
        [Fact]
        public void Sub()
        {
            var result = a - b;

            var e = new Matrix(3, 3);
            for (int x = 0; x < e.SizeX; x++)
                for (int y = 0; y < e.SizeY; y++)
                    e[x, y] = a[x, y] - b[x, y];

            Assert.Equal(e, result);
        }
        [Fact]
        public void Mul()
        {
            var result = a * b;

            var e = new Matrix(3, 3);
            e[0, 0] = 48; e[0, 1] = 57; e[0, 2] = 66;
            e[1, 0] = 32; e[1, 1] = 40; e[1, 2] = 48;
            e[2, 0] = 31; e[2, 1] = 41; e[2, 2] = 51;

            Assert.Equal(e, result);
        }
        [Fact]
        public void AddNumber()
        {
            double number = Math.Round(rnd.NextDouble() * 100, 2);
            var result = a + number;

            var e = new Matrix(3, 3);
            for (int x = 0; x < e.SizeX; x++)
                for (int y = 0; y < e.SizeY; y++)
                    e[x, y] = a[x, y] + number;

            Assert.Equal(e, result);
        }
        [Fact]
        public void SubNumber()
        {
            double number = Math.Round(rnd.NextDouble() * 100, 2);
            var result = a - number;

            var e = new Matrix(3, 3);
            for (int x = 0; x < e.SizeX; x++)
                for (int y = 0; y < e.SizeY; y++)
                    e[x, y] = a[x, y] - number;

            Assert.Equal(e, result);
        }
        [Fact]
        public void MulNumber()
        {
            double number = Math.Round(rnd.NextDouble() * 100, 2);
            var result = a * number;

            var e = new Matrix(3, 3);
            for (int x = 0; x < e.SizeX; x++)
                for (int y = 0; y < e.SizeY; y++)
                    e[x, y] = a[x, y] * number;

            Assert.Equal(e, result);
        }
        [Fact]
        public void Transpose()
        {
            var result = b.Transpose();

            var e = new Matrix(3, 3);
            e[0, 0] = 1; e[0, 1] = 4; e[0, 2] = 7;
            e[1, 0] = 2; e[1, 1] = 5; e[1, 2] = 8;
            e[2, 0] = 3; e[2, 1] = 6; e[2, 2] = 9;

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
        [Fact]
        public void Determinant()
        {
            var result = b.Determinant();

            Assert.Equal(0.0, result);
        }
    }
}
