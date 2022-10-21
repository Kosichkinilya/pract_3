using System;


namespace Lib_8
{
    public static class ExtensionArray
    {

        /// <summary>
        /// ���������� ���������� ������� �� ������ array
        /// </summary>
        /// <param name="numbers">��������� ������ �� ������ Array</param>
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
    }
}
