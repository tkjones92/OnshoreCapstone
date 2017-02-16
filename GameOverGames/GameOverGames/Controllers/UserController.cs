using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BLL.Models;

namespace GameOverGames.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        private StoreLogic humanLg = new StoreLogic();

        // GET: Account
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserVM person)
        {
            humanLg.AddUser(UserVM.Map(person));
            return RedirectToAction("Confirmation");
        }


        public ActionResult Confirmation()
        {
            return View();
        }

        public ActionResult DisplayAdmin()
        {

            return View();
        }

        public ActionResult DisplayEmployee()
        {

            return View();
        }

        public ActionResult DisplayCustomer()
        {

            return View();
        }

        //GET CUSTOMER LIST
        public ActionResult DisplayListofCustomers() //In the creation of new accouts, hide position and let admin update that to create employees
        {
            List<UserVM> UserList = UserVM.Map(humanLg.DisplayCustomer());
            return View(UserList);
        }

        public ActionResult DisplayListofCustomersforEmployee() //In the creation of new accouts, hide position and let admin update that to create employees
        {
            List<UserVM> UserList = UserVM.Map(humanLg.DisplayCustomer());
            return View(UserList);
        }

        //GET EMPLOYEE LIST
        public ActionResult DisplayListofEmployees()
        {
            List<UserVM> UserList = UserVM.Map(humanLg.DisplayEmployee());
            return View(UserList);
        }

        public ActionResult UpdateUserCustomer(int id)
        {
            UserVM human = UserVM.Map(humanLg.GetUserInfoByUserID(id));
            return View(human);
        }

        //POST UPDATEUSER
        [HttpPost]
        public ActionResult UpdateUserCustomer(UserVM person)
        {
            humanLg.UpdateUser(UserVM.Map(person));
            ModelState.Clear();
            ViewBag.Message2 = person.userName + " Successfully Updated";
            return RedirectToAction("DisplayListofCustomers");
        }

        public ActionResult UpdateUserEmployee(int id)
        {
            UserVM human = UserVM.Map(humanLg.GetUserInfoByUserID(id));
            return View(human);
        }

        [HttpPost]
        public ActionResult UpdateUserEmployee(UserVM person)
        {
            humanLg.UpdateUser(UserVM.Map(person));
            ModelState.Clear();
            ViewBag.Message2 = person.userName + " Successfully Updated";
            return RedirectToAction("DisplayListofEmployees");
        }

        public ActionResult UserDetails(int id)
        {
            UserVM human = UserVM.Map(humanLg.GetUserInfoByUserID(id));
            return View(human);
        }

        public ActionResult Login()
        {
            return View();
        }

        //POST Login
        [HttpPost]
        public ActionResult Login(UserVM person)
        {

            var usr = humanLg.Login(person.userName, person.userPassword);
            if (usr != null)
            {
                Session["UserID"] = usr.userID;
                Session["UserName"] = usr.userName;
                Session["Position"] = usr.userPosition;
                ViewBag.Message = person.userName;

                if (usr.userPosition == "Admin" || usr.userPosition == "admin")
                {
                    Session["Admin"] = new UserVM();
                    return RedirectToAction("DisplayAdmin");
                }
                else if (usr.userPosition == "Employee" || usr.userPosition == "employee")
                {
                    return RedirectToAction("DisplayEmployee");
                }
                else if (usr.userPosition == "Customer" || usr.userPosition == "customer")
                {
                    Session["Customer"] = new UserVM();
                    return RedirectToAction("DisplayCustomer");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect UserName or Password");
                }
            }
            else
            {
                return RedirectToAction("Login", "Index");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return View();
        }

    }
}