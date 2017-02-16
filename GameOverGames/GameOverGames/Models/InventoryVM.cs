using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BLL.Models;

namespace GameOverGames.Models
{
    public class InventoryVM
    {
        [Key]
        [Required(ErrorMessage = "Inventory Name is required")]
        public string inventoryName { get; set; }

        [Required(ErrorMessage = "Inventory Price is required")]
        public decimal inventoryPrice { get; set; }

        [Required(ErrorMessage = "Inventory Stock is required")]
        public int inventoryStock { get; set; }

        public int inventoryID { get; set; }

        public static InventoryVM Map(InventorySM human) //Find a way to Map from one List to another List each object
        {
            InventoryVM User = new InventoryVM();
            User.inventoryName = human.inventoryName;
            User.inventoryPrice = human.inventoryPrice;
            User.inventoryStock = human.inventoryStock;
            User.inventoryID = human.inventoryID;
            return User;

        }
        public static InventorySM Map(InventoryVM human)
        {
            InventorySM User = new InventorySM();
            User.inventoryName = human.inventoryName;
            User.inventoryPrice = human.inventoryPrice;
            User.inventoryStock = human.inventoryStock;
            User.inventoryID = human.inventoryID;
            return User;
        }

        public static List<InventorySM> Map(List<InventoryVM> list) //Outside Main need static fields
        {
            List<InventorySM> inventoryList = new List<InventorySM>();
            foreach (InventoryVM human in list)
            {
                inventoryList.Add(Map(human));
            }
            return (inventoryList);
        }

        public static List<InventoryVM> Map(List<InventorySM> list)
        {
            List<InventoryVM> inventoryList = new List<InventoryVM>();
            foreach (InventorySM human in list)
            {
                inventoryList.Add(Map(human));
            }
            return (inventoryList);
        }
    }
}