using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNA_Ecommerce_API.Model
{
    public class Products
    {
        
       // public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }

    }
}
