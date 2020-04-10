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
    struct Cikk
    {
        public int cikkSzam { get; set; }

        public string cikkNev { get; set; }

        public int cikkAr { get; set; }

        public int mennyiseg { get; set; }

        public int ertek { get; set; }
    }
  
    /// <summary>
    /// Interaction logic for Arusitas.xaml
    /// </summary>
    public partial class Arusitas : Window
    {

        public int nulla;
        public string szamok;
        public int karakterhossz;
        public int dbnumber;
        public List<Product> termekek;
        List<Cikk> cikkLista;
        public Arusitas()
        {
            InitializeComponent();
            nulla = 0;
            karakterhossz = 0;
            zero.IsEnabled = false;
            torles.IsEnabled = false;
            klear.IsEnabled = false;
            db.Content = "1";
            dbnumber = 1;
            termekek = new List<Product>();
            cikkLista = new List<Cikk>();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (zero.IsEnabled == true)
            {
                

                szamok = szamok + "0";

                cikkszambox.Text = szamok;
                karakterhossz++;
                torles.IsEnabled=true;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
            zero.IsEnabled = true;

            torles.IsEnabled = true;
            szamok = szamok + "1";

            cikkszambox.Text = szamok;
            karakterhossz++;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            zero.IsEnabled = true;
            torles.IsEnabled = true;

            szamok = szamok + "2";

            cikkszambox.Text = szamok;
            karakterhossz++;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            zero.IsEnabled = true;
            torles.IsEnabled = true;

            szamok = szamok + "3";

            cikkszambox.Text = szamok;
            karakterhossz++;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            zero.IsEnabled = true;
            torles.IsEnabled = true;

            szamok = szamok + "4";

            cikkszambox.Text = szamok;
            karakterhossz++;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            zero.IsEnabled = true;
            torles.IsEnabled = true;

            szamok = szamok + "5";

            cikkszambox.Text = szamok;
            karakterhossz++;
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            zero.IsEnabled = true;
            torles.IsEnabled = true;

            szamok = szamok + "6";

            cikkszambox.Text = szamok;
            karakterhossz++;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            zero.IsEnabled = true;
            torles.IsEnabled = true;

            szamok = szamok + "7";

            cikkszambox.Text = szamok;
            karakterhossz++;
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            zero.IsEnabled = true;
            torles.IsEnabled = true;

            szamok = szamok + "8";

            cikkszambox.Text = szamok;
            karakterhossz++;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            zero.IsEnabled = true;
            torles.IsEnabled = true;

            szamok = szamok + "9";

            cikkszambox.Text = szamok;
            karakterhossz++;
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            if (karakterhossz > 0) {
                int hossz = szamok.Length;
               
                szamok = szamok.Remove(hossz - 1);
                cikkszambox.Text = szamok;
                karakterhossz--;
                if (karakterhossz == 0)
                {
                    zero.IsEnabled = false;
                }
            }
            
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            dbnumber++;
            db.Content = dbnumber.ToString();
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            if (dbnumber > 1)
            {
                dbnumber--;
                db.Content = dbnumber.ToString();

            }
            
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            int vegosszeg = 0;
            Kapcsolatok k1 = new Kapcsolatok();
            Product p2 =(k1.lekerdezTermekekIdSzerint(Convert.ToInt32(cikkszambox.Text.ToString())));
            
            if ( p2!=null)
            {
                if (p2.warehouse > 0)
                {



                    cikkLista.Add(new Cikk
                    {

                        cikkSzam = p2.productId,
                        cikkNev = p2.productName,
                        cikkAr = p2.priceSale,
                        mennyiseg = Convert.ToInt32(db.Content.ToString()),
                        ertek = Convert.ToInt32(p2.priceSale) * Convert.ToInt32(db.Content.ToString()),
                    }

                    );


                    ciksz.Binding = new Binding("cikkSzam");
                    cikkn.Binding = new Binding("cikkNev");
                    cikka.Binding = new Binding("cikkAr");
                    menny.Binding = new Binding("mennyiseg");
                    er.Binding = new Binding("ertek");

                    kosarLista.Items.Clear();
                    for (int j = 0; j < cikkLista.Count(); j++)
                    {
                        kosarLista.Items.Add(cikkLista[j]);
                    }








                    cikkszambox.Text = "";
                    db.Content = "1";
                    szamok = "";
                    for (int i = 0; i < cikkLista.Count(); i++)
                    {
                        vegosszeg = vegosszeg + cikkLista[i].ertek;
                    }

                    veg.Text = vegosszeg.ToString();



                    DataContext = this;
                }

                else
                    if (p2.warehouse <= 0)
                {
                    MessageBox.Show("A termékből nincs készleten jelenleg");
                }
            }

           
            else
                 if (p2 == null)
            {
                MessageBox.Show("Az Ön által bevitt azonosító nem létezi!");
            }


        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            int osszeg = 0;

            for (int i = 0; i < cikkLista.Count(); i++)
            {
                osszeg = osszeg + cikkLista[i].ertek;

            }


            Random r1 = new Random();
            int u = r1.Next(1000, 10000);
            DateTime d1 = DateTime.Now;
            DateTime d2 = new DateTime(d1.Year, d1.Month, d1.Day);
           
            
            Kapcsolatok k1 = new Kapcsolatok();
            k1.addBevetel(u,osszeg,d2.ToString());
            for(int i = 0; i < cikkLista.Count; i++)
            {
                k1.modositKeszlet(cikkLista[i].cikkSzam, cikkLista[i].mennyiseg);
            }
            kosarLista.Items.Clear();
            cikkLista.Clear();
            veg.Text = "";
           

            
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            int szam = 0;

            var selectedItem =kosarLista.SelectedItem;
            if (selectedItem != null)
            {
                
                var itemSelected = (Cikk)kosarLista.SelectedItem;
                kosarLista.Items.Remove(selectedItem);
                for (int k=0;k<cikkLista.Count;k++)
                {
                    if (itemSelected.cikkSzam == cikkLista[k].cikkSzam)
                    {
                        cikkLista.RemoveAt(k);
                    }
                }
                for (int i = 0; i < cikkLista.Count(); i++)
                {
                    szam = szam + cikkLista[i].ertek;
                }

                veg.Text = szam.ToString();

            }
        }

        private void kosarLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            klear.IsEnabled = true;
        }
    }
    
}
