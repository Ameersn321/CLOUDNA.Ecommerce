using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNA_Ecommerce_API.Dto.RequestClass
{
    public class RecentOrderRequest
    {
        public string user { get; set; }
        public string customerId { get; set; }
    }
}
