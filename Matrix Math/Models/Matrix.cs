using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix_Math.Models
{
    public class Matrix
    {
        private double[,] _data;

        public int SizeX { get; }
        public int SizeY { get; }

        public Matrix() : this(3, 3) {}
        public Matrix(int sizeX, int sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            _data = new double[sizeX, sizeY];
        }

        public double this[int x, int y]
        {
            get => _data[x, y];
            set => _data[x, y] = value;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if(a.SizeX != b.SizeX || a.SizeY != b.SizeY)
                throw new ArithmeticException("Matrix sizes should not differ");
            
            Matrix resultMatrix = new Matrix(a.SizeX, a.SizeY);
            for (int x = 0; x < resultMatrix.SizeX; x++)
            {
                for (int y = 0; y < resultMatrix.SizeY; y++)
                {
                    resultMatrix[x, y] = a[x, y] + b[x, y];
                }
            }
            return resultMatrix;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.SizeX != b.SizeX || a.SizeY != b.SizeY)
                throw new ArithmeticException("Matrix sizes should not differ");

            Matrix resultMatrix = new Matrix(a.SizeX, a.SizeY);
            for (int x = 0; x < resultMatrix.SizeX; x++)
            {
                for (int y = 0; y < resultMatrix.SizeY; y++)
                {
                    resultMatrix[x, y] = a[x, y] - b[x, y];
                }
            }
            return resultMatrix;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.SizeX != b.SizeY)
                throw new ArithmeticException("Matrices are not compatible");

            var countOperation = a.SizeX;
            Matrix resultMatrix = new Matrix(a.SizeX, a.SizeY);
            for (int x = 0; x < resultMatrix.SizeX; x++)
            {
                for (int y = 0; y < resultMatrix.SizeY; y++)
                {
                    for (int op = 0; op < countOperation; op++)
                    {
                        resultMatrix[x, y] = a[0, 0] + b[0, 0];
                        //TODO:исправить эту затычку
                    }
                }
            }
            return resultMatrix;
        }
    }
}
