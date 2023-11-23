using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudNA_Ecommerce_API.Model;

namespace CloudNA_Ecommerce_API.Dto.ResponseClass
{
    public class RecentOrderResponse
    {
        public Customers customer { get; set; }
        public Orders orders { get; set; }

    }
}
