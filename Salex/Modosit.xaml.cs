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
    /// Interaction logic for Modosit.xaml
    /// </summary>
    public partial class Modosit : Window
    {
        int a;
        public Modosit()
        {
            InitializeComponent();
            a = 0;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            a++;

            mod.Content = a.ToString();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (a >1)
            {
                a--;

                mod.Content = a.ToString();
            }
            
        }
    }
}
