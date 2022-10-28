using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_8;
using LibArray;

namespace Практическая_2_Косичкин
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Array<int> array = new Array<int>(0, 0);

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_TB(object sender, RoutedEventArgs e)
        {
            Columns_Box.Clear();
            Lines_Box.Clear();
            Calculation_Box.Clear();
        }

        private void Information(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" Вычислить косинус (cos) суммы чисел < 3. \r\n Результат вывести на экран \r\n \r\n Разработчик: Косичкин Илья \r\n ИСП - 34");
        }

        private void To_Perform(object sender, RoutedEventArgs e)
        {
            if (array.Rows != 0 && array.Columns != 0)
            {
                Calculation_Box.Text = $"{ExtensionArray.Difference(array)}";
            }
            else MessageBox.Show("Создайте массив");
        }

        private void Fill(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Lines_Box.Text, out int rows))
            {
                MessageBox.Show("Введте значение");
                Lines_Box.Clear();
                return;

            }
            if (!int.TryParse(Columns_Box.Text, out int column))
            {
                MessageBox.Show("Введите значение");
                Columns_Box.Clear();
                return;

            }

            ExtensionArray.Fill(array, rows, column);
            DataGrid.ItemsSource = array.ToDataTable().DefaultView;
        }
    }
}
