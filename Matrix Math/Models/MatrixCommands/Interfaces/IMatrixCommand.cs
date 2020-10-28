using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix_Math.Models.MatrixCommands.Interfaces
{
    interface IMatrixCommand
    {
        string Title { get; }
        RelayCommand Execute();
    }
}
