using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNA_Ecommerce_API.Model
{
    public class OrderItems
    {
        public string product { get; set; }
        public int quantity { get; set; }
        public decimal priceEach { get; set; }
    }
}
