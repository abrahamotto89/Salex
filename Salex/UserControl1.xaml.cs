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

namespace Salex
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        public int terjesztesiDij;
        public int tavolsag;
        public int benzinKoltseg;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a =Convert.ToInt32(tavKm.Content.ToString()) ;
            int benzin = Convert.ToInt32(tavKm.Content) * 34;
            Random r1 = new Random();
            int ertek = r1.Next(10000);
            Falvak f1 = new Falvak
            {
                id = ertek,
                faluNeve = tnev.Text.ToString(),
                szorolapSzama = Convert.ToInt32(szorolapmenny.Text.ToString()),
                berletiDij = Convert.ToInt32(helypenz.Text.ToString()),
                terjesztesTipus = terjesztes.Text.ToString(),
                terjesztesDij = terjesztesiDij,
                kapcsolat = kapcsolat.Text.ToString(),
                tavolsag = a,
                benzinKoltseg = benzin,
                pontosHely = pontoshelyszin.Text.ToString()
            }
            ;
            Kapcsolatok k1 = new Kapcsolatok();
            k1.insertTelepules(f1);

            tnev.Text = "";
            terjdij.Text = "";
            szorolapmenny.Text = "";
            kapcsolat.Text = "";
            terjdij.Text = "";
            
            helypenz.Text = "";
            tavKm.Content = "";
            tav.Content = "";
            pontoshelyszin.Text = "";
            csuszka.Value = 0;
            terjesztes.SelectedIndex =0 ;
            MessageBox.Show("Település felvételre került");
        }

        private void terjesztes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (terjesztes.SelectedIndex)
            {
                case 1:
                    terjesztesiDij = Convert.ToInt32(szorolapmenny.Text.ToString())*9;
                    break;

                case 2:
                    terjesztesiDij = Convert.ToInt32(terjdij.Text.ToString());
                    break;

                case 3:
                    terjesztesiDij = Convert.ToInt32(terjdij.Text.ToString());
                    break;
                default:
                    break;
            }
        }

        private void csuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            // ... Get Value.
            double value = slider.Value;
         
            // ... Set Window Title.
            slider.Maximum = 100;
            tavKm.Content = value.ToString("0");
            


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double f = 10.0202020122020202;
            int convert = Convert.ToInt32(f);
            Console.WriteLine(convert);
            int vissza= (Convert.ToInt32(Convert.ToDouble(csuszka.Value.ToString())))*34;
            tav.Content = vissza.ToString();


            
            

        }
    }
}
