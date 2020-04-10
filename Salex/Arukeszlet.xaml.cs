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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections;
using System.Windows.Controls.Primitives;
using System.IO;
using System.Data;
namespace Salex
{
   struct MinKeszlet
    {
        public int cikkSzam { get; set; }
        public string cikkNev { get; set; }

        public int keszletDb { get; set; }

        
        public int rendeltMennyiseg { get; set;
        }
    }

    struct Rendelkeszlet
    {
        public int cikkSzam { get; set; }

        public string cikkNev { get; set; }

        public int rendeltMennyiseg { get; set; }

     
    }
    /// <summary>
    /// Interaction logic for Arukeszlet.xaml
    /// </summary>
    public partial class Arukeszlet : Window
    {
        List<MinKeszlet> min;
        int a;

        List<Rendelkeszlet> vegleges;
        public Arukeszlet()
        {
            InitializeComponent();
            keszletErtek();
            min = new List<MinKeszlet>();
            getRendelendoAruk();


            vegleges = new List<Rendelkeszlet>();

            a = 0;
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
        public void keszletErtek()
        {
            Kapcsolatok k1 = new Kapcsolatok();
            keszletDisplay.Content = k1.lekerdezArukeszletBeszerzesi().ToString();
            ertekesitesDisplay.Content = k1.lekerdezArukeszletEladasi().ToString();

        }

        public void getRendelendoAruk()
        {

            List<Product> getKeszlet = new List<Product>();

            Kapcsolatok k1 = new Kapcsolatok();
            getKeszlet = k1.getKeszletRendelendo();
            cikksz.Binding = new Binding("cikkSzam");
            cikkn.Binding = new Binding("cikkNev");
            keszlet.Binding = new Binding("keszletDb");
            rmenny.Binding = new Binding("rendeltMennyiseg");

            for (int k = 0; k < getKeszlet.Count; k++)
            {
                min.Add(new MinKeszlet
                {
                    cikkSzam = getKeszlet[k].productId,
                    cikkNev = getKeszlet[k].productName,
                    keszletDb = getKeszlet[k].warehouse,
                    rendeltMennyiseg = getKeszlet[k].minLevel - getKeszlet[k].warehouse,

                });
            }



            for (int j = 0; j < min.Count; j++)
            {
                keszletRendeles.Items.Add(new MinKeszlet
                {
                    cikkSzam = min[j].cikkSzam,
                    cikkNev = min[j].cikkNev,
                    keszletDb = min[j].keszletDb,
                    rendeltMennyiseg = min[j].rendeltMennyiseg

                });
            }

            DataContext = this;
        }





        private void keszletRendeles_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            e.Cancel = true;
        }

        private void katt_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MinKeszlet)keszletRendeles.SelectedItem;

            vegleges.Add(new Rendelkeszlet
            {
                cikkSzam = Convert.ToInt32(selected.cikkSzam.ToString()),
                cikkNev = selected.cikkNev.ToString(),
                rendeltMennyiseg = Convert.ToInt32(selected.rendeltMennyiseg.ToString())
            });

            keszletRendeles.Items.Remove(selected);



        }

        private void veg_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf(createDatatable());
            MessageBox.Show("Rendelését rögzítettük");

        }





        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }




        public void ExportToPdf(DataTable dt)
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("Rendeles.pdf", FileMode.Create));
            document.Open();

            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f, };

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));

            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {
                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    
                }
            }
            document.AddAuthor("Incsik-Land Kft");
            document.AddHeader("Rendelés", "Vattacukor Műhely");
            document.Add(table);

            document.Close();
        }



        public DataTable createDatatable()
        {




            DataTable data = new DataTable();
            data.Columns.Add("Cikkszám", typeof(string));
            data.Columns.Add("Cikk Neve:", typeof(string));
            data.Columns.Add("Rendelt Mennyiség", typeof(int));

            for (int i = 0; i < vegleges.Count; i++)
            {
                data.Rows.Add(vegleges[i].cikkSzam, vegleges[i].cikkNev, vegleges[i].rendeltMennyiseg);
            }

            /*
            int szam = 0;
            int szam2 = 0;
            for (int i = 0; i < vegleges.Count; i++)
            {
                szam = szam + rendel[i].RendelMennyi;

            }

            data.Rows.Add("", "", 0, szam, 0, Convert.ToInt32(Rertek.Content.ToString()));
            */
            // ... Add two rows.
            // ... Display first field.






            return (data);
        }
    }
    }
