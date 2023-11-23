using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNA_Ecommerce_API.Model
{
    public class Orders
    {
        public int orderNumber { get; set; }
        public string orderDate { get; set; }
        public string deliveryAddress { get; set; }
        public List<OrderItems> orderItems { get; set; }
        public string deliveryExpected { get; set; }
    }
}
