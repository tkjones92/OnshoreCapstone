using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public class InventorySM
    {
        public string inventoryName { get; set; }
        public decimal inventoryPrice { get; set; }
        public int inventoryStock { get; set; }
        public int inventoryID { get; set; }
    }
}
