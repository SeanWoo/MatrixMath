using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix_Math.Models.Exceptions
{
    public class MatrixException : Exception
    {
        public MatrixException(string? message) : base(message) { }
    }
}
