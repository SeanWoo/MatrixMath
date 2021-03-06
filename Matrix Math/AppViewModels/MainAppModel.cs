﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Dynamic;
using System.Data;
using Matrix_Math.Models.Extensions;
using Matrix_Math.Models;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using Microsoft.VisualBasic.FileIO;
using System.Windows;
using Matrix_Math.Models.Exceptions;

namespace Matrix_Math.AppViewModels
{
    public class MainAppModel : INotifyPropertyChanged
    {
        private bool _overwrite = false;
        private Matrix _firstMatrix;
        private Matrix _secondMatrix;
        private Matrix _resultMatrix;
        private MatrixCommand _selectedMatrixCommand;

        private RelayCommand _openFirstFileCommand;
        private RelayCommand _openSecondFileCommand;
        private RelayCommand _selectResultFileCommand;

        public string FirstFile { get; private set; }
        public string SecondFile { get; private set; }
        public string ResultFile { get; private set; }

        public string Number { get; set; }

        public DataTable ResultMatrix {
            get
            {
                _resultMatrix?.Round(3);
                return _resultMatrix?.ToDataTable();
            }
        }

        public List<MatrixCommand> MatrixCommands { get; set; } = new List<MatrixCommand>()
        {
            new MatrixCommand("Сложить матрицы", (a, b, c) => a + b),
            new MatrixCommand("Прибавить к матрице число", (a, b, c) => a + Convert.ToDouble(c)),
            new MatrixCommand("Вычесть матрицы", (a, b, c) => a - b),
            new MatrixCommand("Вычесть из матрицы число", (a, b, c) => a - Convert.ToDouble(c)),
            new MatrixCommand("Умножить первую на вторую матрицу", (a, b, c) => a * b),
            new MatrixCommand("Умножить вторую на первую матрицу", (a, b, c) => b * a),
            new MatrixCommand("Умножить матрицу на число", (a, b, c) => a * Convert.ToDouble(c)),
            new MatrixCommand("Определитель первой матрицы", (a, b, c) => a.Determinant()),
            new MatrixCommand("Определитель второй матрицы", (a, b, c) => b.Determinant()),
            new MatrixCommand("Обратная первая матрица", (a, b, c) => a.InverseMatrix()),
            new MatrixCommand("Обратная вторая матрица", (a, b, c) => b.InverseMatrix()),
            new MatrixCommand("Транспонирование первой матрицы", (a, b, c) => a.Transpose()),
            new MatrixCommand("Транспонирование второй матрицы", (a, b, c) => b.Transpose()),
        };

        public MatrixCommand SelectedMatrixCommand { 
            get => _selectedMatrixCommand;
            set 
            {
                _selectedMatrixCommand = value;
                try
                {
                    var resultMatrix = _selectedMatrixCommand.Execute(
                        _firstMatrix ?? new Matrix(),
                        _secondMatrix ?? new Matrix(),
                        Number);

                    if(resultMatrix is double)
                        _resultMatrix = new Matrix(1, 1, (double)resultMatrix);
                    else if(resultMatrix is Matrix)
                        _resultMatrix = resultMatrix as Matrix;

                    OnPropertyChanged("ResultMatrix");
                }
                catch(MatrixException ex) 
                {
                    MessageBox.Show(ex.Message);
                }
                if (!string.IsNullOrWhiteSpace(ResultFile))
                {
                    var fs = File.Create(ResultFile);
                    using (fs)
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            string result = "";
                            for (int x = 0; x < _resultMatrix.SizeX; x++)
                            {
                                for (int y = 0; y < _resultMatrix.SizeY; y++)
                                {
                                    result += _resultMatrix[x, y] + ",";
                                }
                                result = result.Remove(result.Length - 1) + "\n";
                            }
                            sw.Write(result);
                        }
                    }
                }
            } 
        }

        public RelayCommand OpenFirstFileCommand => _openFirstFileCommand ?? new RelayCommand((o) => OpenFile());
        public RelayCommand OpenSecondFileCommand => _openSecondFileCommand ?? new RelayCommand((o) => OpenFile());
        public RelayCommand SelectResultFileCommand
        {
            get
            {
                return _selectResultFileCommand ?? new RelayCommand((o) => {
                    SaveFileDialog sf = new SaveFileDialog();
                    if ((sf.ShowDialog() ?? false) == true)
                    {
                        ResultFile = sf.FileName;
                        _overwrite = sf.OverwritePrompt;
                        if (!ResultFile.Contains(".csv"))
                            ResultFile += ".csv";
                        OnPropertyChanged(nameof(ResultFile));
                    }
                });
            }
        }
        


        private void OpenFile([CallerMemberName]string select = "")
        {
            OpenFileDialog d = new OpenFileDialog();
            if((d.ShowDialog() ?? false) == true)
            {
                switch (select)
                {
                    case "OpenFirstFileCommand":
                        FirstFile = d.FileName;
                        _firstMatrix = ParseMatrix(FirstFile);
                        OnPropertyChanged(nameof(FirstFile));
                        break;
                    case "OpenSecondFileCommand":
                        SecondFile = d.FileName;
                        _secondMatrix = ParseMatrix(SecondFile);
                        OnPropertyChanged(nameof(SecondFile));
                        break;
                    default:
                        break;
                }
            }
        }

        private Matrix ParseMatrix(string path)
        {
            Matrix matrix;
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                var list = new List<double[]>();
                while (!parser.EndOfData)
                {
                    try
                    {
                        var fields = parser.ReadFields().Select(x => Convert.ToDouble(x)).ToArray();
                        list.Add(fields);
                    }
                    catch
                    {
                        MessageBox.Show("Не корректное содержимое файла. Возможно у Вас запятые в конце строк");
                        return null;
                    }
                }
                matrix = new Matrix(list.Count, list[0].Length);
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < list[0].Length; j++)
                    {
                        matrix[i, j] = list[i][j];
                    }
                }
            }
            return matrix;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        
    }
}
