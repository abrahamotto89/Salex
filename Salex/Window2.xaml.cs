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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Hozzáad_Click(object sender, RoutedEventArgs e)
        {
            Random r2 = new Random();
            int nagykerAzonosito = r2.Next(1,100);
            Kapcsolatok k2 = new Kapcsolatok();
            k2.insertNagyker(nagykerAzonosito,nagykernev.Text,ncim.Text,ntel.Text,nemail.Text);
            nagykernev.Text = "";
            ncim.Text = "";
            ntel.Text = "";
            nemail.Text = "";
            this.Close();

        }
    }
}
