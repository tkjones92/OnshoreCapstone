using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BLL.Models;
using GameOverGames.Models;

namespace GameOverGames.Controllers
{
    public class InventoryController : Controller
    {
        private StoreLogic humanLg = new StoreLogic();
        // GET: Inventory
        public ActionResult inventoryIndex()
        {
            return View();
        }

        public ActionResult AddInventory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInventory(InventoryVM person)  //This is creating new products 
        {
            humanLg.AddInventory(InventoryVM.Map(person));
            return RedirectToAction("inventoryConfirmation");
        }

        public ActionResult inventoryConfirmation() //This confirms a product was created. Used for admin only, takes admin back 
        {                                           //to the Main admin page or back to the List or products            
            return View();
        }

        public ActionResult DisplayInventory()
        {
            return View(InventoryVM.Map(humanLg.DisplayInventory()));

        }

        public ActionResult DisplayInventoryEmployee()
        {
            return View(InventoryVM.Map(humanLg.DisplayInventory()));
        }

        public ActionResult DisplayInventoryCustomer()
        {
            return View(InventoryVM.Map(humanLg.DisplayInventory()));
        }

        public ActionResult UpdateInventory(int id)
        {
            InventoryVM human = InventoryVM.Map(humanLg.GetInventoryInfoByInventoryID(id));
            return View(human);
        }

        //POST UPDATEUSER
        [HttpPost]
        public ActionResult UpdateInventory(InventoryVM person)
        {
            humanLg.UpdateInventory(InventoryVM.Map(person));
            ModelState.Clear();
            ViewBag.Message2 = person.inventoryName + " Successfully Updated";
            return RedirectToAction("DisplayInventory");
        }
    }
}