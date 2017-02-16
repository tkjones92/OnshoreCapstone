using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using DAL;
using DAL.Models;

namespace BLL
{
    public class StoreLogic
    {
        StoreData userData = new StoreData();
        public void AddUser(UserSM human)
        {
            StoreData userData = new StoreData();
            userData.CreateUser(Map(human));
        }
        public void AddInventory(InventorySM human) //Rename human to item 
        {
            StoreData userData = new StoreData();
            userData.CreateInventory(Map(human));
        }

        public void UpdateUser(UserSM user)
        {
            StoreData userData = new StoreData();
            userData.UpdateUser(Map(user));
        }

        public void UpdateInventory(InventorySM user)
        {
            StoreData userData = new StoreData();
            userData.UpdateInventory(Map(user));
        }

        public List<UserSM> DisplayCustomer()
        {
            StoreData userData = new StoreData();
            return Map(userData.DisplayCustomer());
        }
        public List<UserSM> DisplayEmployee()
        {
            StoreData userData = new StoreData();
            return Map(userData.DisplayEmployee());
        }

        public List<InventorySM> DisplayInventory()
        {
            StoreData userData = new StoreData();
            return Map(userData.DisplayInventory());
        }
      
        public void DeleteInventory(InventorySM user)
        {
            StoreData userData = new StoreData();
            userData.DeleteInventory(Map(user));
        }

        public UserSM GetUserInfoByUserID(int id)
        {
            StoreData userData = new StoreData();
            return Map(userData.GetUserInfoByUserID(id));
        }

        public InventorySM GetInventoryInfoByInventoryID(int id)
        {
            StoreData userData = new StoreData();
            return Map(userData.GetInventoryInfoByInventoryID(id));
        }

        public UserSM Login(string userName, string pass)
        {
            StoreData userData = new StoreData();
            return Map(userData.GetUserInfoByNameandPass(userName, pass));
        }

        public UserDM Map(UserSM human)
        {
            UserDM user = new UserDM();
            user.userFirstName = human.userFirstName;
            user.userLastName = human.userLastName;
            user.userName = human.userName;
            user.userPassword = human.userPassword;
            user.ConfirmUserPassword = human.ConfirmUserPassword;
            user.userEmail = human.userEmail;
            user.ConfirmUserEmail = human.ConfirmUserEmail;
            user.userPhoneNumber = human.userPhoneNumber;
            user.userStreet = human.userStreet;
            user.userCity = human.userCity;
            user.userState = human.userState;
            user.userZipcode = human.userZipcode;
            user.userID = human.userID;
            user.userPosition = human.userPosition;
            return user;
        }

        public UserSM Map(UserDM human)
        {
            UserSM user = new UserSM();
            user.userFirstName = human.userFirstName;
            user.userLastName = human.userLastName;
            user.userName = human.userName;
            user.userPassword = human.userPassword;
            user.ConfirmUserPassword = human.ConfirmUserPassword;
            user.userEmail = human.userEmail;
            user.ConfirmUserEmail = human.ConfirmUserEmail;
            user.userPhoneNumber = human.userPhoneNumber;
            user.userStreet = human.userStreet;
            user.userCity = human.userCity;
            user.userState = human.userState;
            user.userZipcode = human.userZipcode;
            user.userID = human.userID;
            user.userPosition = human.userPosition;
            return user;
        }

        public InventoryDM Map(InventorySM human)
        {
            InventoryDM user = new InventoryDM();
            user.inventoryName = human.inventoryName;
            user.inventoryPrice = human.inventoryPrice;
            user.inventoryStock = human.inventoryStock;
            user.inventoryID = human.inventoryID;
            return user;
        }

        public InventorySM Map(InventoryDM human)
        {
            InventorySM user = new InventorySM();
            user.inventoryName = human.inventoryName;
            user.inventoryPrice = human.inventoryPrice;
            user.inventoryStock = human.inventoryStock;
            user.inventoryID = human.inventoryID;
            return user;
        }

        public List<UserDM> Map(List<UserSM> list)
        {
            List<UserDM> userList = new List<UserDM>();
            foreach (UserSM human in list)
            {
                userList.Add(Map(human));
            }
            return (userList);
        }

        public List<UserSM> Map(List<UserDM> list)
        {
            List<UserSM> userList = new List<UserSM>();
            foreach (UserDM human in list)
            {
                userList.Add(Map(human));
            }
            return (userList);
        }

        public List<InventoryDM> Map(List<InventorySM> list)
        {
            List<InventoryDM> inventoryList = new List<InventoryDM>();
            foreach (InventorySM human in list)
            {
                inventoryList.Add(Map(human));
            }
            return (inventoryList);
        }

        public List<InventorySM> Map(List<InventoryDM> list)
        {
            List<InventorySM> inventoryList = new List<InventorySM>();
            foreach (InventoryDM human in list)
            {
                inventoryList.Add(Map(human));
            }
            return (inventoryList);
        }
    }
}
