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

    


    /// <summary>
    /// Interaction logic for TermekList.xaml
    /// </summary>
    public partial class TermekList : Window
    {

        public List<Product> lista;
        public List<Nagyker> nagyKerLista;
        public TermekList()
        {
            InitializeComponent();
            lista = new List<Product>();
            selectTermek();
            fillNagyker();
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void selectTermek()
        {
            productList.Items.Clear();
            lista.Clear();
            
            Kapcsolatok k1 = new Kapcsolatok();
            lista=(k1.lekerdezTermekek());
            id.Binding = new Binding("productId");
            pnev.Binding = new Binding("productName");
            bp.Binding = new Binding("priceBuy");
            sp.Binding = new Binding("priceSale");
            w.Binding = new Binding("warehouse");
            cId.Binding = new Binding("companyId");
            min.Binding = new Binding("minLevel");

            for(int i = 0; i < lista.Count(); i++)
            {
                productList.Items.Add(lista[i]);
            }

            DataContext = this;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TermekFelvetel tf1 = new TermekFelvetel();
            tf1.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Arukeszlet a1 = new Arukeszlet();
            a1.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Arukeszlet a1 = new Arukeszlet();
            a1.Show();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            
            ExportToPdf(createDatatable());
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
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("TermékLista.pdf", FileMode.Create));
            document.Open();

            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 4f, 4f, 4f,4f,4f,4f,4f };

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
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                    table.AddCell(new Phrase(r[4].ToString(), font5));
                    table.AddCell(new Phrase(r[5].ToString(), font5));
                    table.AddCell(new Phrase(r[6].ToString(), font5));
           

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
            data.Columns.Add("Beszerzési Ár:", typeof(int));
            data.Columns.Add("Eladási Ár:", typeof(string));
            data.Columns.Add("Aktuális Készlet", typeof(string));
            data.Columns.Add("NagyKer Id", typeof(int));
            data.Columns.Add("Min.Készlet", typeof(string));
           
            for (int i = 0; i < lista.Count; i++)
            {
                data.Rows.Add(lista[i].productId, lista[i].productName, lista[i].priceBuy, lista[i].priceSale, lista[i].warehouse, lista[i].companyId, lista[i].minLevel);
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


        public void fillNagyker()
        {
            Kapcsolatok k1 = new Kapcsolatok();
            nagyKerLista = new List<Nagyker>();
            nagyKerLista = k1.fillNagyker();

            for (int i = 0; i < nagyKerLista.Count; i++)
            {
                nagykerCombo.Items.Add(nagyKerLista[i].nagykerNev);
            }
        }

        

       

        private void nagykerCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(nagykerCombo.SelectedIndex);
            Console.WriteLine(nagykerCombo.Text);


            switch (nagykerCombo.SelectedIndex)
            {
                case 0:
                    selectTermek();

                    break;
                case 1:
                    fillSelectedNagyker("Hétfejű Sárkány Kft.");
                    break;
                case 2:
                    fillSelectedNagyker("Jackie");
                    break;
                case 3:
                    fillSelectedNagyker("Zhenyun Chen Kft");
                    break;
                case 4:
                    fillSelectedNagyker("Euro-TT Kft");
                    break;

                case 5:
                    fillSelectedNagyker("Sangyoun Kft");
                    break;
                case 6:
                    fillSelectedNagyker("RuházatiKinai Kft");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

        public void fillSelectedNagyker(string nev)
        {
            List<Product> nagykerSzerint = new List<Product>();
            productList.Items.Clear();
            lista.Clear();

            
            Kapcsolatok k1 = new Kapcsolatok();
            nagykerSzerint = k1.lekerdezTermekekNagyKerSzerint(nev);

            id.Binding = new Binding("productId");
            pnev.Binding = new Binding("productName");
            bp.Binding = new Binding("priceBuy");
            sp.Binding = new Binding("priceSale");
            w.Binding = new Binding("warehouse");
            cId.Binding = new Binding("companyId");
            min.Binding = new Binding("minLevel");

            for (int i = 0; i < nagykerSzerint.Count(); i++)
            {
                productList.Items.Add(nagykerSzerint[i]);
                lista.Add(nagykerSzerint[i]);
            }

            for (int i = 0; i < nagykerSzerint.Count(); i++)
            {

                Console.WriteLine(lista[i].productId);
            }

            DataContext = this;
        }
    }
}
