using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKBC.Controllers
{
    public class Products
    {
        public int ProdID { get; set; }
        public string Name { get; set; }
        public int CatID { get; set; }
        public int StoclLevel { get; set; }
        public double Price { get; set; }
    }
}
