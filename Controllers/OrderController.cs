using CloudNA_Ecommerce_API.Dto.RequestClass;
using CloudNA_Ecommerce_API.Dto.ResponseClass;
using CloudNA_Ecommerce_API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNA_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)=> _orderRepository = orderRepository;

        [HttpPost]

        public async Task<ActionResult<List<RecentOrderResponse>>> GetRecentOrderDetails([FromBody]RecentOrderRequest orderRequest)
        {
            if(orderRequest==null || string.IsNullOrEmpty(orderRequest.customerId)|| string.IsNullOrEmpty(orderRequest.user))
            {
                return BadRequest("Invalid Data");
            }
            else if(!await _orderRepository.ValidateCustomerEmail(orderRequest))
            {

                return BadRequest("Email Address is not valid for the Customer");
            }
            else
            {
                var result = await _orderRepository.GetRecentOrderDetails(orderRequest);
                return Ok(result);
            }
          


        }

    }
}
