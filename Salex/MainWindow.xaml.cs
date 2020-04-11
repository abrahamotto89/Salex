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
using LiveCharts;
using LiveCharts.Wpf;
namespace Salex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            beillesztGrafikon();
            beillesztGrafikon2();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            TermekFelvetel k1 = new TermekFelvetel();
            k1.Show();

            MessageBox.Show("Megnyitva");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            TermekList t1 = new TermekList();
            t1.Show();
        }

        public void beillesztGrafikon()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
           string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            piechart.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = "Szórólap",
                Values = new ChartValues<double> {3},
                PushOut = 15,
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = "Üzemanyag",
                Values = new ChartValues<double> {4},
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = "Kézbesítés",
                Values = new ChartValues<double> {6},
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = "Helypénz",
                Values = new ChartValues<double> {2},
                DataLabels = true,
                LabelPoint = labelPoint
            }
        };

            piechart.LegendLocation = LegendLocation.Bottom;
        }


        public void beillesztGrafikon2()
        {
            CartesianChart ch = new CartesianChart();
            ch.Series = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Series 1",
            Values = new ChartValues<double> { 1500000, 1750000, 1850000, 1300000 ,1000000 }
        }
    };
            testGrid.Children.Add(ch);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Arukeszlet a1 = new Arukeszlet();
            a1.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Arusitas a1 = new Arusitas();
            a1.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Bevetel b1 = new Bevetel();
            b1.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Arusitas a1 = new Arusitas();
            a1.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Telepulesek t1 = new Telepulesek();
            t1.Show();
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            Szervezes sz1 = new Szervezes();
            sz1.Show();
        }
    }
}
