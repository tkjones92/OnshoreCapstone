using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class InventoryDM
    {
        public string inventoryName { get; set; }
        public decimal inventoryPrice { get; set; }
        public int inventoryStock { get; set; }
        public int inventoryID { get; set; }
    }
}
