using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNA_Ecommerce_API.DataContext
{
    public class EcommerceDbContext
    {
        public readonly IConfiguration _configuration;
        public readonly string _connectionstring;

        public EcommerceDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("EcomdbConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
