using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKBC.Models
{
    public class Products
    {
        public int ProdID { get; set; }
        public string Name { get; set; }
        public int CatID { get; set; }
        public int ScentID { get; set; }
        public int StockLevel { get; set; }
        public double Price { get; set; }
        public string CatName { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Scents> Scents { get; set; }
        public IEnumerable<ScentName> ScentName { get; set; }

    }
}
