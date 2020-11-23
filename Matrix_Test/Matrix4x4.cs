using Matrix_Math.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Matrix_Test
{
    public class Matrix4x4
    {
        private Matrix a = new Matrix(4, 4);

        public Matrix4x4()
        {
            a[0, 0] = 5; a[0, 1] = 4; a[0, 2] = 5; a[0, 3] = 5;
            a[1, 0] = 2; a[1, 1] = 2; a[1, 2] = 6; a[1, 3] = 2;
            a[2, 0] = 6; a[2, 1] = 3; a[2, 2] = 5; a[2, 3] = 1; 
            a[3, 0] = 7; a[3, 1] = 4; a[3, 2] = 4; a[3, 3] = 6;
        }

        [Fact]
        public void Determinant()
        {
            var result = a.Determinant();

            Assert.Equal(96.0, result);
        }
    }
}
