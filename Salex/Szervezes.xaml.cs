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

   

    

    public struct Next28Day
    {
        public int a { get; set; }
        public string Date
        {
            get; set;
        }

        public string hetnapja { get; set; }
    }



   
    /// <summary>
    /// Interaction logic for Szervezes.xaml
    /// </summary>
    public partial class Szervezes : Window
    {

        public static string a = "falu0101";
        public Szervezes()
        {
            InitializeComponent();
            fillLista();
            fillButtoms();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        public List<Next28Day> fillLista()
        {
            List<Next28Day> lista = new List<Next28Day>();
            for (int i = 2; i < 31; i++)
            {
                DateTime d1 = DateTime.Now.AddDays(i);

                string n = d1.ToLongDateString();
                char[] s;
                char[] s2;
                s = n.ToCharArray();
                int x = 0;
                for (int z = 0; z < s.Length; z++)
                {
                    if (s[z] == ',')
                    {
                        x = z;

                    }
                }


                string vissza = n.ToString();
                int leng = vissza.Length - 1;


                string a = d1.Month.ToString();
                string b = d1.Day.ToString();
                string c = "";
                if (d1.Month < 10 && d1.Day < 10)
                {
                    c = "0" + a + "." + "0" + b;
                }

                if (d1.Month > 9 && d1.Day > 9)
                {
                    c = a + "." + b;
                }
                if (d1.Month < 10 && d1.Day > 9)
                {
                    c = "0" + a + "." + b;
                }
                if (d1.Month > 9 && d1.Day < 10)
                {
                    c = a + "." + "0" + b;
                }


                lista.Add(new Next28Day
                {
                    a = i - 1,
                    Date = c,
                    hetnapja = vissza.Remove(0, x + 2).ToString(),

                });







            }

            for (int k = 0; k < lista.Count; k++)
            {
                Console.WriteLine(lista[k].a + lista[k].Date + lista[k].hetnapja);
            }



            datum1.Text = lista[0].Date;
            nap0101.Text = lista[0].hetnapja;
            datum2.Text = lista[1].Date;
            nap0102.Text = lista[1].hetnapja;
            datum3.Text = lista[2].Date;
            nap0103.Text = lista[2].hetnapja;
            datum4.Text = lista[3].Date;
            nap0104.Text = lista[3].hetnapja;
            datum5.Text = lista[4].Date;
            nap0105.Text = lista[4].hetnapja;
            datum6.Text = lista[5].Date;
            nap0106.Text = lista[5].hetnapja;
            datum7.Text = lista[6].Date;
            nap0107.Text = lista[6].hetnapja;

            datum8.Text = lista[7].Date;
            nap0108.Text = lista[7].hetnapja;
            datum9.Text = lista[8].Date;
            nap0109.Text = lista[8].hetnapja;
            datum10.Text = lista[9].Date;
            nap0110.Text = lista[9].hetnapja;
            datum11.Text = lista[10].Date;
            nap0111.Text = lista[10].hetnapja;
            datum12.Text = lista[11].Date;
            nap0112.Text = lista[11].hetnapja;
            datum13.Text = lista[12].Date;
            nap0113.Text = lista[12].hetnapja;
            datum14.Text = lista[13].Date;
            nap0114.Text = lista[13].hetnapja;

            datum15.Text = lista[14].Date;
            nap0115.Text = lista[14].hetnapja;
            datum16.Text = lista[15].Date;
            nap0116.Text = lista[15].hetnapja;
            datum17.Text = lista[16].Date;
            nap0117.Text = lista[16].hetnapja;
            datum18.Text = lista[17].Date;
            nap0118.Text = lista[17].hetnapja;
            datum19.Text = lista[18].Date;
            nap0119.Text = lista[18].hetnapja;
            datum20.Text = lista[19].Date;
            nap0120.Text = lista[19].hetnapja;
            datum21.Text = lista[20].Date;
            nap0121.Text = lista[20].hetnapja;

            datum22.Text = lista[21].Date;
            nap0122.Text = lista[21].hetnapja;
            datum23.Text = lista[22].Date;
            nap0123.Text = lista[22].hetnapja;
            datum24.Text = lista[23].Date;
            nap0124.Text = lista[23].hetnapja;
            datum25.Text = lista[24].Date;
            nap0125.Text = lista[24].hetnapja;
            datum26.Text = lista[25].Date;
            nap0126.Text = lista[25].hetnapja;
            datum27.Text = lista[26].Date;
            nap0127.Text = lista[26].hetnapja;
            datum28.Text = lista[27].Date;
            nap0128.Text = lista[27].hetnapja;
            datum29.Text = lista[28].Date;
            nap0129.Text = lista[28].hetnapja;

            return (lista);

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            DateTime d1 = (Convert.ToDateTime(datum1.Text.ToString()));
              
            Window window = new Window
            {
                Title = "My User Control Dialog",
                Content = new UserControl5(d1),
                Height = 200,  // just added to have a smaller control (Window)
                Width = 240
            };

            window.ShowDialog();
        }

        public void fillButtoms()
        {
            List<string> datumok = new List<string>();

            datumok.Add(datum1.Text);
            datumok.Add(datum2.Text);
            datumok.Add(datum3.Text);
            datumok.Add(datum4.Text);
            datumok.Add(datum5.Text);
            datumok.Add(datum6.Text);
            datumok.Add(datum7.Text);
            datumok.Add(datum8.Text);
            datumok.Add(datum9.Text);
            datumok.Add(datum10.Text);
            datumok.Add(datum12.Text);
            datumok.Add(datum13.Text);
            datumok.Add(datum14.Text);
            datumok.Add(datum15.Text);
            datumok.Add(datum16.Text);
            datumok.Add(datum17.Text);
            datumok.Add(datum18.Text);
            datumok.Add(datum19.Text);
            datumok.Add(datum20.Text);
            datumok.Add(datum21.Text);
            datumok.Add(datum22.Text);
            datumok.Add(datum23.Text);
            datumok.Add(datum24.Text);
            datumok.Add(datum25.Text);
            datumok.Add(datum26.Text);
            datumok.Add(datum27.Text);

            datumok.Add(datum28.Text);
            List<Szervez> lista = new List<Szervez>();
            Kapcsolatok k1 = new Kapcsolatok();
            lista = k1.getSzervezes();
           //DateTime parseDateTime = DateTime.Parse();
            
            int x = 0;

          
            for(int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].datum == DateTime.Parse(datumok[0]))
                {
                    falu0101.Content = lista[i].delelott;
                    falu0102.Content = lista[i].delutam;
                    koltseg0101.Text = lista[i].koltseg.ToString();
                    szorolap0101.Text = lista[i].szorolapSzam.ToString();

                }

              
               
            }
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].datum == DateTime.Parse(datumok[1]))
                {
                    falu10102.Content = lista[i].delelott;
                    falu20102.Content = lista[i].delutam;
                    koltseg0102.Text = lista[i].koltseg.ToString();
                    szorolap0102.Text = lista[i].szorolapSzam.ToString();

                }



            }
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].datum == DateTime.Parse(datumok[2]))
                {
                    falu10103.Content = lista[i].delelott;
                    falu20103.Content = lista[i].delutam;
                    koltseg0103.Text = lista[i].koltseg.ToString();
                    szorolap0103.Text = lista[i].szorolapSzam.ToString();

                }



            }
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].datum == DateTime.Parse(datumok[3]))
                {
                    falu0104.Content = lista[i].delelott;
                    falu0204.Content = lista[i].delutam;
                    koltseg0104.Text = lista[i].koltseg.ToString();
                    szorolap0104.Text = lista[i].szorolapSzam.ToString();

                }



            }
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].datum == DateTime.Parse(datumok[4]))
                {
                    falu0105.Content = lista[i].delelott;
                    falu0205.Content = lista[i].delutam;
                    koltseg0105.Text = lista[i].koltseg.ToString();
                    szorolap0105.Text = lista[i].szorolapSzam.ToString();

                }



            }
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].datum == DateTime.Parse(datumok[5]))
                {
                    falu0106.Content = lista[i].delelott;
                    falu0106.Content = lista[i].delutam;
                    koltseg0106.Text = lista[i].koltseg.ToString();
                    szorolap0106.Text = lista[i].szorolapSzam.ToString();

                }



            }
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].datum == DateTime.Parse(datumok[6]))
                {
                    falu0107.Content = lista[i].delelott;
                    falu0207.Content = lista[i].delutam;
                    koltseg0107.Text = lista[i].koltseg.ToString();
                    szorolap0107.Text = lista[i].szorolapSzam.ToString();

                }



            }




        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            

            fillButtoms();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DateTime d1 = (Convert.ToDateTime(datum2.Text.ToString()));

            Window window = new Window
            {
                Title = "My User Control Dialog",
                Content = new UserControl5(d1),
                Height = 200,  // just added to have a smaller control (Window)
                Width = 240
            };

            window.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            DateTime d1 = (Convert.ToDateTime(datum3.Text.ToString()));

            Window window = new Window
            {
                Title = "My User Control Dialog",
                Content = new UserControl5(d1),
                Height = 200,  // just added to have a smaller control (Window)
                Width = 240
            };

            window.ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            DateTime d1 = (Convert.ToDateTime(datum4.Text.ToString()));

            Window window = new Window
            {
                Title = "My User Control Dialog",
                Content = new UserControl5(d1),
                Height = 200,  // just added to have a smaller control (Window)
                Width = 240
            };

            window.ShowDialog();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            DateTime d1 = (Convert.ToDateTime(datum5.Text.ToString()));

            Window window = new Window
            {
                Title = "My User Control Dialog",
                Content = new UserControl5(d1),
                Height = 200,  // just added to have a smaller control (Window)
                Width = 240
            };

            window.ShowDialog();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Window7 w7 = new Window7();
            w7.Show();
        }
    }
}
