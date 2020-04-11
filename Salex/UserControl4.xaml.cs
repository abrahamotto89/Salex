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
    /// Interaction logic for UserControl4.xaml
    /// </summary>
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
           
            InitializeComponent();

            fillDataGrid();
        }



        public void fillDataGrid()
        {
            List<Falvak> lista = new List<Falvak>();
            
          

            Kapcsolatok k1 = new Kapcsolatok();
            lista = k1.getFalvak();


            for(int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine(lista[i].id);
            }

            GridData.ItemsSource = lista;
          

        }
    }
}
