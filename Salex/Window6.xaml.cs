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
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
            fillFalvak();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void fillFalvak()
        {
            Kapcsolatok k1 = new Kapcsolatok();
            List<Falvak> lista = new List<Falvak>();
            lista = k1.getFalvak();
            List<string> falunevek = new List<string>();

            for(int i = 0; i < lista.Count; i++)
            {
                falunevek.Add(lista[i].faluNeve);
            }

            faluk.ItemsSource = falunevek;
            faluk2.ItemsSource = falunevek;

        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
    }
}
