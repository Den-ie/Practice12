using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Practice12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Height += 25;
        }

        private void Calculate1(object sender, RoutedEventArgs e)
        {
            RibLength.Focus();
            if (int.TryParse(RibLength.Text, out int A))
            {
                double V = Math.Pow(A, 3);
                double S = Math.Pow(A, 2);

                Volume.Text = V.ToString();
                Square.Text = S.ToString();
            }
            else MessageBox.Show("Введите число");
        }

        private void RibChanged(object sender, TextChangedEventArgs e)
        {
            Volume.Text = null;
            Square.Text = null;
        }

        private void Clear1(object sender, RoutedEventArgs e)
        {

            Volume.Clear();
            Square.Clear();
        }

        private void Calculate2(object sender, RoutedEventArgs e)
        {
            Kilos.Focus();
            int Tons = 0;
            if (int.TryParse(Kilos.Text, out int Kg))
            {
                while (Kg >= 1000)
                {
                    Kg -= 1000;
                    Tons++;
                }
                Ton.Text = Tons.ToString();
                Kgs.Text = Kg.ToString();
            }
            else MessageBox.Show("Введите число");
        }
        private void NumberChange(object sender, TextChangedEventArgs e)
        {
            Ton.Text = null;
            Kgs.Text = null;
        }

        private void Clear2(object sender, RoutedEventArgs e)
        {
            Kgs.Clear();
            Ton.Clear();
        }

        DispatcherTimer timer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            time.Text = t.ToString("hh:mm:ss");
            data.Text = t.ToString("dd.MM.yyyy");
        }

        private void AboutProgramm1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана длина ребра куба А. Найти объем куба V и площадь его поверхности S.");
        }

        private void AboutProgramm2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана масса M в килограммах. \rИспользуя операцию деления целых чисел, найти количество полных тонн и килограмм (1 тонна = 1000 кг).");
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
