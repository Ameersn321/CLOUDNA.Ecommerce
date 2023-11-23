using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudNA_Ecommerce_API.Dto.RequestClass;
using CloudNA_Ecommerce_API.Dto.ResponseClass;

namespace CloudNA_Ecommerce_API.Repository.Interface
{
    public interface IOrderRepository
    {
        public Task<List<RecentOrderResponse>> GetRecentOrderDetails(RecentOrderRequest recentOrderRequest);

        public Task<bool> ValidateCustomerEmail(RecentOrderRequest recentOrderRequest);
        
    }
}
