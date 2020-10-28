using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Linq;
using System.Dynamic;
using System.Data;
using Matrix_Math.Models.Extensions;
using Matrix_Math.Models;
using System.Collections.ObjectModel;

namespace Matrix_Math.AppViewModels
{
    public class MainAppModel : INotifyPropertyChanged
    {
        private const int START_MATRIX_X = 3;
        private const int START_MATRIX_Y = 3;

        private int _viewMatrixSizeX = START_MATRIX_X;
        private int _viewMatrixSizeY = START_MATRIX_Y;

        public int[] Numbers { get; set; } = Enumerable.Range(1, 99).ToArray();
        public DataView Matrix { get; set; } = new int[START_MATRIX_X, START_MATRIX_Y].ToDataTable().DefaultView;

        public ObservableCollection<MatrixFrame> MatrixFrames { get; set; } = new ObservableCollection<MatrixFrame>()
        {
            new MatrixFrame(){Name = "Frame 1", Matrix = new Matrix()},
            new MatrixFrame(){Name = "Frame 2", Matrix = new Matrix()},
        };

        public int SelectedNumberX 
        { 
            get => _viewMatrixSizeX;
            set
            {
                _viewMatrixSizeX = value;
                //TODO: Вызов функции для ресайза DataView
                OnPropertyChanged("Matrix");
            }
        }
        public int SelectedNumberY
        {
            get => _viewMatrixSizeY;
            set
            {
                _viewMatrixSizeY = value;
                //TODO: Вызов функции для ресайза DataView
                OnPropertyChanged("Matrix");
            }
        }

        //public List<MatrixCommand> MatrixFunctions { get; set; }

        public MainAppModel()
        {
            var a = new Matrix(2, 2);
            a[0, 0] = 5; a[0, 1] = 6;
            a[1, 0] = 7; a[1, 1] = 8;
            var b = new Matrix(2, 2);
            b[0, 0] = 15; b[0, 1] = 16;
            b[1, 0] = 17; b[1, 1] = 18;

            var c = a + b;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        
    }
}
