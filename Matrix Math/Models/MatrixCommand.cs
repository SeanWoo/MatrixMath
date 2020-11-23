using Matrix_Math.AppViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix_Math.Models
{
    public class MatrixCommand
    {
        public string Description { get; set; }
        public Func<Matrix, Matrix, object, Matrix> Execute { get; set; }

        public MatrixCommand(string description, Func<Matrix, Matrix, object, Matrix> execute)
        {
            Description = description;
            Execute = execute;
        }
    }
}
