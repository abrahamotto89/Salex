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
using LiveCharts.Wpf;
using LiveCharts;
namespace Salex
{
    /// <summary>
    /// Interaction logic for Bevetel.xaml
    /// </summary>
    public partial class Bevetel : Window
    {

        public string napi;
        public string heti;
        public string havi;
        public Bevetel()
        {
            InitializeComponent();
            //  addNapiBevetel();
            beillesztTop4();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void addNapiBevetel()
        {


            Kapcsolatok k1 = new Kapcsolatok();
           List<double> napi = k1.getNapiBevetel();
           
            CartesianChart ch = new CartesianChart();
            ch.Series = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Napi bevétel alakulása",
            Values = new ChartValues<double> {napi[0],napi[1],napi[2],napi[3],napi[4] }
          

            
        }
    };
            grafikonNapi.Children.Add(ch);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime today= DateTime.Now;
            DateTime week = today.AddDays(-7);
            DateTime mon = today.AddDays(-30);
            Console.WriteLine(today);
            Console.WriteLine(week);

            if (today.Month > 9 && today.Day<10)
            {
                 napi = today.Year + ". 0" + today.Month + ". " + today.Day + ". " + "0:00:00";

            }

            if(today.Month<10 && today.Day>9)
            {
                 napi = today.Year + ". 0" + today.Month + ". " + today.Day + ". " + "0:00:00";
            }

            if (today.Month > 9 && today.Day > 9)
            {
                 napi = today.Year + ". " + today.Month + ". " + today.Day + ". " + "0:00:00";
            }

            if (today.Month < 10 && today.Day < 10)
            {
                 napi = today.Year + ". 0" + today.Month + ". 0" + today.Day + ". " + "0:00:00";
            }
            

            if (week.Month < 10 && week.Day > 9)
            {
                 heti = week.Year + ". 0" + week.Month + ". " + week.Day + ". " + "0:00:00";
            }

            if (week.Month > 9 && week.Day > 9)
            {
                 heti = week.Year + ". " + week.Month + ". " + week.Day + ". " + "0:00:00";
            }

            if (week.Month < 10 && week.Day < 10)
            {
                 heti = week.Year + ". 0" + week.Month + ". 0" + week.Day + ". " + "0:00:00";
            }
            if (week.Month > 9 && week.Day < 10)
            {
                 heti = week.Year + ". " + week.Month + ". 0" + week.Day + ". " + "0:00:00";
            }

            if (mon.Month > 9 && mon.Day < 10)
            {
                havi = mon.Year + ". 0" + mon.Month + ". " + mon.Day + ". " + "0:00:00";

            }

            if (mon.Month < 10 && mon.Day > 9)
            {
                havi = mon.Year + ". 0" + mon.Month + ". " + mon.Day + ". " + "0:00:00";
            }

            if (mon.Month > 9 && mon.Day > 9)
            {
                havi = mon.Year + ". " + mon.Month + ". " + mon.Day + ". " + "0:00:00";
            }

            if (mon.Month < 10 && mon.Day < 10)
            {
                havi = mon.Year + ". 0" + mon.Month + ". 0" + mon.Day + ". " + "0:00:00";
            }

            Console.WriteLine(napi);
            Console.WriteLine(heti);

            switch (bevetelValaszt.SelectedIndex)
            {

                case 0:
                    getNapi(napi);
                    break;

                case 1:
                    getHeti(napi,heti);
                    break;
                case 2:

                    getHeti(napi,havi);
                    break;

                default:
                        break;
            }
        }

        public void getNapi(string x)
        {
            string napi = "";
            DateTime today = DateTime.Now;

            if (today.Month > 9 && today.Day < 10)
            {
                napi = today.Year + ". 0" + today.Month + ". " + today.Day + ". " + "0:00:00";

            }

            if (today.Month < 10 && today.Day > 9)
            {
                napi = today.Year + ". 0" + today.Month + ". " + today.Day + ". " + "0:00:00";
            }

            if (today.Month > 9 && today.Day > 9)
            {
                napi = today.Year + ". " + today.Month + ". " + today.Day + ". " + "0:00:00";
            }

            if (today.Month < 10 && today.Day < 10)
            {
                napi = today.Year + ". 0" + today.Month + ". 0" + today.Day + ". " + "0:00:00";
            }


            Kapcsolatok k1 = new Kapcsolatok();
            if (k1.getLastDate() != napi)
            {
                bevetelGomb.Content = "0";
            }
            else
            {
                bevetelGomb.Content = k1.getBevetelNapi(x);
            }
           
        }

        public void getHeti(string x,string y)
        {

            Kapcsolatok k1 = new Kapcsolatok();
            bevetelGomb.Content = k1.getBevetelHeti(x,y);
        }

        public void beillesztTop4()
        {

            Kapcsolatok k1 = new Kapcsolatok();
            List<BevetelDatum> top4 = new List<BevetelDatum>();
            top4 = k1.getTop4Bevetel();
            Func<ChartPoint, string> labelPoint = chartPoint =>
           string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            top4chart.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = top4[0].datum.ToString(),
                Values = new ChartValues<double> {Convert.ToDouble(top4[0].bevetel)},
                PushOut = 15,
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = top4[1].datum.ToString(),
                Values = new ChartValues<double> {Convert.ToDouble(top4[1].bevetel)},
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = top4[2].datum.ToString(),
                Values = new ChartValues<double> {Convert.ToDouble(top4[2].bevetel)},
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = top4[3].datum.ToString(),
                Values = new ChartValues<double> {Convert.ToDouble(top4[3].bevetel)},
                DataLabels = true,
                LabelPoint = labelPoint
            }
        };

            top4chart.LegendLocation = LegendLocation.Bottom;
        }
    }
}

