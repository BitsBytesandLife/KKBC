using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KKBC.Models
{
    public class StockLevels
    {
        public int ProdID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int StockLevel { get; set; }
    }
}
