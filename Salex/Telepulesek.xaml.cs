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
    /// Interaction logic for Telepulesek.xaml
    /// </summary>
    public partial class Telepulesek : Window
    {
        public Telepulesek()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(kivalaszt.SelectedIndex);
            switch(kivalaszt.SelectedIndex)

            {
                case 0:
                    GridUser.Children.Add(new UserControl4());
                    break;
                case 1:
                    GridUser.Children.Add(new UserControl1());
                    break;
                case 2:
                    GridUser.Children.Add(new UserControl2());
                    break;

                case 3:
                    GridUser.Children.Add(new UserControl3());
                    break;

                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
