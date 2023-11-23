using CloudNA_Ecommerce_API.DataContext;
using CloudNA_Ecommerce_API.Dto.RequestClass;
using CloudNA_Ecommerce_API.Dto.ResponseClass;
using CloudNA_Ecommerce_API.Repository.Interface;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNA_Ecommerce_API.Repository.RepositoryClass
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceDbContext _ecommerceDbContext;

        public OrderRepository(EcommerceDbContext ecommerceDbContext) => _ecommerceDbContext = ecommerceDbContext;
        public async Task<List<RecentOrderResponse>> GetRecentOrderDetails(RecentOrderRequest recentOrderRequest)
        {
            string query = @"
                SELECT
                    c.FirstName AS 'customer.firstName',
                    c.LastName AS 'customer.lastName',
                    o.OrderId AS 'orders.orderNumber',
                    o.OrderDate AS 'orders.orderDate',
                    c.HouseNo + ' ' + c.Street + ',' + c.Town + ',' + c.PostCode AS 'orders.deliveryAddress',
                    (
                        SELECT
                            CASE 
							WHEN o.CONTAINSGIFT=1 THEN 'GIFT' ELSE p.ProductName END AS 'product',
                            oi.Quantity AS 'quantity',
                            oi.Price AS 'priceEach'
                        FROM
                            OrderItems oi
                            INNER JOIN Products p ON p.ProductId = oi.ProductId
                        WHERE
                            oi.OrderId = o.OrderId
                        FOR JSON PATH
                    ) AS 'orders.orderItems',
                    o.DeliveryExpected AS 'orders.deliveryExpected'
                FROM
                    Customers c
                    LEFT JOIN Orders o ON c.CustomerId = o.CustomerId
                WHERE
                     c.CustomerID=@CustomerID and c.Email=@User
                FOR JSON PATH;";


            using (var con = _ecommerceDbContext.CreateConnection())
            {
                string jsonResult = await con.QueryFirstOrDefaultAsync<string>(query, new { CustomerID = recentOrderRequest.customerId, User = recentOrderRequest.user });
                List<RecentOrderResponse> objOrderResponse = JsonConvert.DeserializeObject<List<RecentOrderResponse>>(jsonResult);
                return objOrderResponse;

            }
        }

        public async Task<bool> ValidateCustomerEmail(RecentOrderRequest recentOrderRequest)
        {
            string query = @"
               SELECT
                     CASE
                     WHEN COUNT(*) > 0 THEN 'True'
                     ELSE 'False'
                         END AS ValidationStatus
                FROM
                Customers
                WHERE
                CustomerID = @CustomerID
                AND (Email IS NULL OR Email = @User);";


            using (var con = _ecommerceDbContext.CreateConnection())
            {
                bool validate = await con.QueryFirstOrDefaultAsync<bool>(query, new { CustomerID = recentOrderRequest.customerId, User = recentOrderRequest.user });
                return validate;

            }
        }
    }
}
