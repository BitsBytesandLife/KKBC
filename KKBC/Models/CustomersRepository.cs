using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace KKBC.Models
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly IDbConnection _conn;
        public CustomersRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return _conn.Query<Customers>("SELECT * FROM customers;");
        }
    }
}
