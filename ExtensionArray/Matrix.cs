using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Controls;
using System.Windows.Media;

#pragma warning disable SYSLIB0011

// для класса матрикс нужна отдельная библиотека 
namespace LibMatrix
{
    public class Matrix<T>
    {

        private T[,] _items;
        private int _rows, _columns;

        public Matrix(int rowCount, int columnCount, string extension = ".matrix")
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

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    _items[i, j] = default;
                }
            }
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

        private static readonly BinaryFormatter _formatter = new BinaryFormatter();

        public void Save(object data, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(stream, data);
            }
        }

        public object Open(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return _formatter.Deserialize(stream);
            }
        }

        public void Serialize(string path)
        {
            Save(_items, string.Concat(path));
        }

        public void Deserialize(string path)
        {
            _items = (T[,])Open(string.Concat(path));
        }
    }
}