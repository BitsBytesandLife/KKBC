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

        public void DeleteCustomer(Customers cust)
        {
            _conn.Execute("DELETE FROM customers WHERE custID = @id;",
                                      new { id = cust.CustID });

        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return _conn.Query<Customers>("SELECT * FROM customers;");
        }

        public Customers GetCustomer(int id)
        {
                return _conn.QuerySingle<Customers>("SELECT * FROM customers where CustID = @id",
                    new { id = id });
        }

        public Customers GetCustomer(Customers cust)
        {
            return _conn.QuerySingle<Customers>("SELECT * FROM customers where CustID = @id",
                new { id = cust.CustID });
        }

        public void InsertCustomer(Customers customerToInsert)
        {
            _conn.Execute("INSERT INTO customers (FirstName,LastName,Address,City,State,ZipCode) values(@firstName,@lastName,@address,@city,@state,@zipCode);",
                           new
                           {
                               firstName = customerToInsert.FirstName,
                               lastName = customerToInsert.LastName,
                               address = customerToInsert.Address,
                               city = customerToInsert.City,
                               state = customerToInsert.State,
                               zipCode = customerToInsert.ZipCode
                           });
        }

        public Customers NewCustomer(Customers cust)
        {
            return cust;
        }

        public void UpdateCustomer(Customers cust)
        {
             _conn.Execute("UPDATE customers SET FirstName = @firstName, LastName = @lastName, Address = @address, " +
                                 "City = @city, State = @state, ZipCode = @zipCode WHERE CustID = @id",
                                 new { firstName = cust.FirstName, lastName = cust.LastName,address=cust.Address, city = cust.City, 
                                      state = cust.State, zipCode = cust.ZipCode, id = cust.CustID});
            
        }

    }
}
