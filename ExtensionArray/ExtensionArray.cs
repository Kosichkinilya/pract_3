using System;


namespace Lib_8
{
    public static class ExtensionArray
    {

        /// <summary>
        /// Заполнение двумерного массива из класса array
        /// </summary>
        /// <param name="numbers">Двумерный массив из класса Array</param>
        /// <param name="rows">Значение строк которые мы получаем от пользователя</param>
        /// <param name="column">Значение столбцов которые мы получаем от пользователя</param>
        /// <param name="minValue">Минимальное значение для случайного числа</param>
        /// <param name="maxValue">Максимальное значение для случайного числа</param>

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
