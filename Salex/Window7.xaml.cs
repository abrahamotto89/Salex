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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
namespace Salex
{
    /// <summary>
    /// Interaction logic for Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        public Window7()
        {
            InitializeComponent();
            addGrafikon();
            beillesztGrafikon();

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void addGrafikon()
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
            grafikonGrid.Children.Add(ch);
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
    }

}

