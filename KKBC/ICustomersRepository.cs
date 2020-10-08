using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKBC.Models
{
    public interface ICustomersRepository
    {
        public IEnumerable<Customers> GetAllCustomers();
        public Customers GetCustomer(int id);
        public Customers GetCustomer(Customers cust);
        public Customers NewCustomer(Customers cust);
        public void UpdateCustomer(Customers cust);
        public void InsertCustomer(Customers customerToInsert);
        public void DeleteCustomer(Customers cust);

    }
}
