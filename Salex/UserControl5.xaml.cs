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
    /// Interaction logic for UserControl5.xaml
    /// </summary>
    public partial class UserControl5 : UserControl
    {
        public DateTime  date;
        public UserControl5(DateTime d)
        {
            date = d;
            InitializeComponent();
            fillFalvak();
        }
        public void fillFalvak()
        {
            Kapcsolatok k1 = new Kapcsolatok();
            List<Falvak> lista = new List<Falvak>();
            lista = k1.getFalvak();
            List<string> falunevek = new List<string>();

            for (int i = 0; i < lista.Count; i++)
            {
                falunevek.Add(lista[i].faluNeve);
            }

            faluk.ItemsSource = falunevek;
            faluk2.ItemsSource = falunevek;


        }

    

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            

            Kapcsolatok k1 = new Kapcsolatok();
            Random r1 = new Random();
            List<Szervez> szervezesekLista = new List<Szervez>();
            szervezesekLista = k1.getSzervezes();
            List<Falvak> falvak = new List<Falvak>();

            falvak = k1.getFalvak();


            int koltsegek = 0;
            int szorolapMennyiseg = 0;
            bool valtoztat = true;
            for (int i = 0; i < szervezesekLista.Count; i++)
            {
                if (szervezesekLista[i].datum == date)
                {
                    valtoztat = false;
                }

            }
            if (valtoztat == true)
            {
                for (int i = 0; i < falvak.Count; i++)
                {
                    if (falvak[i].faluNeve == faluk.Text.ToString())
                    {
                        koltsegek = koltsegek + falvak[i].berletiDij + falvak[i].benzinKoltseg + falvak[i].terjesztesDij + falvak[i].szorolapSzama * 9;
                        szorolapMennyiseg = szorolapMennyiseg + falvak[i].szorolapSzama;
                    }

                    if (falvak[i].faluNeve == faluk2.Text.ToString())
                    {
                        koltsegek = koltsegek + falvak[i].berletiDij + falvak[i].benzinKoltseg + falvak[i].terjesztesDij + falvak[i].szorolapSzama * 9;
                        szorolapMennyiseg = szorolapMennyiseg + falvak[i].szorolapSzama;
                    }

                }
                int azon = r1.Next(1000);
                Szervez sz = new Szervez
                {
                    id = azon,
                    delelott = faluk.Text.ToString(),
                    delutam = faluk2.Text.ToString(),
                    koltseg = koltsegek,
                    szorolapSzam
           = szorolapMennyiseg,
                    datum = date
                };


                k1.insertSzervezes(sz);
            }



           
           


          

            else
            {

                k1.deleteSzervezes(date);
                for (int i = 0; i < falvak.Count; i++)
                {
                    if (falvak[i].faluNeve == faluk.Text.ToString())
                    {
                        koltsegek = koltsegek + falvak[i].berletiDij + falvak[i].benzinKoltseg + falvak[i].terjesztesDij + falvak[i].szorolapSzama * 9;
                        szorolapMennyiseg = szorolapMennyiseg + falvak[i].szorolapSzama;
                    }

                    if (falvak[i].faluNeve == faluk2.Text.ToString())
                    {
                        koltsegek = koltsegek + falvak[i].berletiDij + falvak[i].benzinKoltseg + falvak[i].terjesztesDij + falvak[i].szorolapSzama * 9;
                        szorolapMennyiseg = szorolapMennyiseg + falvak[i].szorolapSzama;
                    }

                }
                int azon = r1.Next(1000);
                Szervez sz = new Szervez
                {
                    id = azon,
                    delelott = faluk.Text.ToString(),
                    delutam = faluk2.Text.ToString(),
                    koltseg = koltsegek,
                    szorolapSzam
           = szorolapMennyiseg,
                    datum = date
                };


                k1.insertSzervezes(sz);

            }
            

            Window.GetWindow(this).Close();
        }
    }
}
