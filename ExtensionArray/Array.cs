using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;




namespace LibArray
{
    public class Array<T>
    {

        private T[,] _items;
        private int _rows, _columns;

        public Array(int rowCount, int columnCount, string extension = ".array")
        {
            _items = new T[rowCount, columnCount];
            Extension = extension;
        }


        public string Extension { get; private set; }


        public T this[int row, int column]
        {
            get { return _items[row, column]; }
            set { _items[row, column] = value; }
        }

        public void DefaultInit()
        {
            _items = default;
            _rows = default;
            _columns = default;
        }

        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _items.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < _items.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < _items.GetLength(1); j++)
                {
                    row[j] = _items[i, j];
                }

                res.Rows.Add(row);
            }
            return res;
        }

        public void Add(T[,] items) // 
        {
            _rows = items.GetLength(0); // колво строк 
            _columns = items.GetLength(1); // колвоколонок 
            _items = new T[_rows, _columns]; // число ввденных пользователем строек и колонок 
            for (int i = 0; i < items.GetLength(0); i++)
            {
                for (int j = 0; j < items.GetLength(1); j++)
                {
                    _items[i, j] = items[i, j];
                }
            }
        }

        public int Rows
        {
            get => _rows; // получение значения из поля _rows
            private set // установка значения для поля _rows
            {
                if (value == _rows)
                {
                    return;
                }
                _rows = value;
            }
        }

        public int Columns
        {
            get => _columns; // получение значения из поля _columns
            private set // установка значения для поля _columns
            {
                if (value == _columns)
                {
                    return;
                }
                _columns = value;
            }
        }

    }

}