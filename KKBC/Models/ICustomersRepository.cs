using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKBC.Models
{
    public interface ICustomersRepository
    {
        public IEnumerable<Customers> GetAllCustomers();
    }
}
