using System;
using LibArray;

namespace Lib_8
{
    public static class ExtensionArray
    {
        public static void FillArray(Array<int> array, int rows, int column)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ���������� ���������� ������� �� ������ Matrix
        /// </summary>
        /// <param name="numbers">��������� ������ �� ������ Matrix</param>
        /// <param name="rows">�������� ����� ������� �� �������� �� ������������</param>
        /// <param name="column">�������� �������� ������� �� �������� �� ������������</param>
        /// <param name="minValue">����������� �������� ��� ���������� �����</param>
        /// <param name="maxValue">������������ �������� ��� ���������� �����</param>
        public static void Fill(this Array<int> numbers, int rows, int column)
        {
            int[,] array = new int[rows, column];
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = rnd.Next(-10, 10);
                }
            }
            numbers.Add(array);
        }
        /// <summary>
        /// ������� ������� �����
        /// </summary>
        /// <param name="numbers">��������� ������ �� ������ Array</param>
        /// <returns></returns>
        public static double Difference(this Array<int> numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Rows; i++)
            {
                for (int j = 0; j < numbers.Columns; j++)
                {
                    if (numbers[i, j] < 3) sum += numbers[i, j];
                }
            }
            if (sum == 0) return 0;
            else
                return Math.Round(Math.Cos(sum), 3);
        }
    }
}
