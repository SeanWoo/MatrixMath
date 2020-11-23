using System.Data;

namespace Matrix_Math.Models.Extensions
{
    public static class ArrayExtension
    {
        public static DataTable ToDataTable<T>(this T[,] matrix)
        {
            var res = new DataTable();

            for (int i = 0; i < matrix.GetLength(1); i++)
                res.Columns.Add(i.ToString(), typeof(T));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < matrix.GetLength(1); j++)
                    row[j] = matrix[i, j];
                res.Rows.Add(row);
            }

            return res;
        }
        public static double[,] ArraySub(this double[,] arr, int lx, int ly)
        {
            int size = arr.GetLength(0);
            double[,] result = new double[size - 1, size - 1];
            int realX = 0;
            int realY = 0;
            for (int x = 0; x < size; x++)
            {
                if (x == lx) continue;
                realY = 0;
                for (int y = 0; y < size; y++)
                {
                    if (y == ly) continue;

                    result[realX, realY] = arr[x, y];

                    realY++;
                }
                realX++;
            }

            return result;
        }
    }
}
