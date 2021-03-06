﻿using Matrix_Math.Models.Exceptions;
using Matrix_Math.Models.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        public Matrix(int sizeX, int sizeY, double defaultValue)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            _data = new double[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
                for (int y = 0; y < sizeY; y++)
                    _data[x, y] = defaultValue;
        }
        public Matrix(double[,] matrix)
        {
            SizeX = matrix.GetLength(0);
            SizeY = matrix.GetLength(1);
            _data = new double[SizeX, SizeY];
            for (int x = 0; x < SizeX; x++)
                for (int y = 0; y < SizeY; y++)
                    _data[x, y] = matrix[x, y];
        }

        public double this[int x, int y]
        {
            get => _data[x, y];
            set => _data[x, y] = value;
        }

        public DataTable ToDataTable() => _data.ToDataTable();

        public static Matrix operator +(Matrix a, double b)
        {
            Matrix resultMatrix = new Matrix(a.SizeX, a.SizeY);
            for (int x = 0; x < resultMatrix.SizeX; x++)
            {
                for (int y = 0; y < resultMatrix.SizeY; y++)
                {
                    resultMatrix[x, y] = a[x, y] + b;
                }
            }
            return resultMatrix;
        }
        public static Matrix operator -(Matrix a, double b)
        {
            Matrix resultMatrix = new Matrix(a.SizeX, a.SizeY);
            for (int x = 0; x < resultMatrix.SizeX; x++)
            {
                for (int y = 0; y < resultMatrix.SizeY; y++)
                {
                    resultMatrix[x, y] = a[x, y] - b;
                }
            }
            return resultMatrix;
        }
        public static Matrix operator *(Matrix a, double b)
        {
            Matrix resultMatrix = new Matrix(a.SizeX, a.SizeY);
            for (int x = 0; x < resultMatrix.SizeX; x++)
            {
                for (int y = 0; y < resultMatrix.SizeY; y++)
                {
                    resultMatrix[x, y] = a[x, y] * b;
                }
            }
            return resultMatrix;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.SizeX != b.SizeX || a.SizeY != b.SizeY)
                throw new MatrixException("Вы не можете сложить матрицы разных размеров");

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
                throw new MatrixException("Вы не можете вычесть матрицы разных размеров");

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
            if (a.SizeY != b.SizeX)
                throw new MatrixException("Вы не можете умножить матрицы если количество столбцов первой матрицы не равно количеству столбцов второй матрицы");

            Matrix resultMatrix = new Matrix(a.SizeX, b.SizeY);
            for (int i = 0; i < resultMatrix.SizeX; i++)
            {
                for (int j = 0; j < resultMatrix.SizeY; j++)
                {
                    var res = 0.0;
                    for (int op = 0; op < b.SizeX; op++)
                    {
                        res += a[i, op] * b[op, j];
                    }
                    resultMatrix[i, j] = res;
                }
            }
            return resultMatrix;
        }

        public double Determinant()
        {
            if (SizeX != SizeY)
                throw new MatrixException("Вы не можете высчитать определитель не квадратной матрицы");

            return DeterminantRecursive(_data);
        }
        public Matrix Transpose()
        {
            var resultMatrix = new Matrix(SizeY, SizeX);
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    resultMatrix[y, x] = _data[x, y];
                }
            }
            return resultMatrix;
        }
        public Matrix InverseMatrix()
        {
            var resultMatrix = new Matrix(SizeX, SizeY);
            var detetminant = Determinant();
            var complements = new double[SizeX, SizeY];

            var transposeMatrix = Transpose()._data;
            double[,] subMatrix;

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    subMatrix = transposeMatrix.ArraySub(x, y);
                    resultMatrix[x, y] = (Math.Pow(-1, (x+1) + (y+1)) * new Matrix(subMatrix).Determinant()) / detetminant;
                }
            }
            return resultMatrix;
        }

        public void Round(int decimals)
        {
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    _data[x, y] = Math.Round(_data[x, y], decimals);
                }
            }
        }

        private double DeterminantRecursive(double [,] arr)
        {
            double result;
            int minor;
            int sizeMatrix = arr.GetLength(0);
            double[,] subMatrix;
            switch (sizeMatrix)
            {
                case 1:
                    return arr[0, 0];
                case 2:
                    return arr[0, 0] * arr[1, 1] - arr[0, 1] * arr[1, 0];
                default:
                    result = 0.0;
                    minor = 1;
                    for (int x = 0; x < sizeMatrix; x++)
                    {
                        subMatrix = arr.ArraySub(x, 0);
                        result = result + minor * arr[x, 0] * DeterminantRecursive(subMatrix);
                        minor = -minor;
                    }
                    return result;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is null || !(obj is Matrix)) return false;

            var otherMatrix = (Matrix)obj;
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    if (_data[x, y] != otherMatrix[x, y])
                        return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_data, SizeX, SizeY);
        }
    }
}
