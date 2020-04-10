using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salex
{
 public class Product
    {
       
        public int productId { get; set; }
        public string productName { get; set; }

        public int priceBuy { get; set; }

        public int priceSale { get; set; }

        public int warehouse { get; set; }

        public int companyId { get; set; }

        public int minLevel { get; set; }

        
    }   
}
