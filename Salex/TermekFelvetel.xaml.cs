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

namespace Salex
{

    /// <summary>
    /// Interaction logic for TermekFelvetel.xaml
    /// </summary>
    public partial class TermekFelvetel : Window
    {
        public List<String> nagykerLista;
        public TermekFelvetel()
        {
            InitializeComponent();

            nagykerLista = new List<String>();

            Kapcsolatok k1 = new Kapcsolatok();
            nagykerLista=k1.lekerdezNagyker();

            for(int i = 0; i < nagykerLista.Count(); i++)
            {
                nagykervalaszt.Items.Add(nagykerLista[i]);
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Hozzáad_Click(object sender, RoutedEventArgs e)
        {

            Random r1 = new Random();
            int azonosito = r1.Next(100,999);
            Kapcsolatok k1 = new Kapcsolatok();
            
            k1.insertProduct(azonosito,tnev.Text,Convert.ToInt32(bar.Text),Convert.ToInt32(ear.Text),Convert.ToInt32(vdb.Text), k1.lekerdezNagyKerId(nagykervalaszt.Text),Convert.ToInt32(minkeszlet.Text));
            bar.Text = "";
            ear.Text = "";
            tnev.Text = "";
            vdb.Text = "";
            minkeszlet.Text = "";
            nagykervalaszt.Text = "";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            nagykervalaszt.Items.Clear();
            Kapcsolatok k1 = new Kapcsolatok();
            nagykerLista = k1.lekerdezNagyker();

            for (int i = 0; i < nagykerLista.Count(); i++)
            {
                nagykervalaszt.Items.Add(nagykerLista[i]);
            }
        }
    }
}
