using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DAL.Models;

namespace DAL
{
    public class StoreData
    {
        public string ConnectionString = @"Server =DESKTOP-SKDDMQB\SQLEXPRESS;Initial Catalog=CapstoneStore;Integrated Security=True;";

        public void CreateUser(UserDM user)
        {
            try
            {
                //Creating a way of adding new user information to my database 
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AddUser", myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userFirstName", user.userFirstName);
                        cmd.Parameters.AddWithValue("@userLastName", user.userLastName);
                        cmd.Parameters.AddWithValue("@userName", user.userName);
                        cmd.Parameters.AddWithValue("@userPassword", user.userPassword);
                        cmd.Parameters.AddWithValue("@userEmail", user.userEmail);
                        cmd.Parameters.AddWithValue("@userPhoneNumber", user.userPhoneNumber);
                        cmd.Parameters.AddWithValue("@userStreet", user.userStreet);
                        cmd.Parameters.AddWithValue("@userCity", user.userCity);
                        cmd.Parameters.AddWithValue("@userState", user.userState);
                        cmd.Parameters.AddWithValue("@userZipcode", user.userZipcode);
                        cmd.Parameters.AddWithValue("@userPosition", user.userPosition);
                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CreateInventory(InventoryDM user)
        {
            try
            {
                //Identify repetitive code and place within a method that can be called from anywhere.
                //Make them as general enough so it can be use more than once
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AddInventory", myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@inventoryName", user.inventoryName);
                        cmd.Parameters.AddWithValue("@inventoryPrice", user.inventoryPrice);
                        cmd.Parameters.AddWithValue("@inventoryStock", user.inventoryStock);
                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<UserDM> DisplayCustomer()
        {
            List<UserDM> userList = new List<UserDM>();
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    myConnection.Open();  
                    using (SqlCommand cmd = new SqlCommand("CustomerList", myConnection))
                    {
                        cmd.Connection = myConnection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var cust = new UserDM();
                                    if (!reader.IsDBNull(reader.GetOrdinal("userFirstName")))
                                        cust.userFirstName = reader.GetString(reader.GetOrdinal("userFirstName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userLastName")))
                                        cust.userLastName = reader.GetString(reader.GetOrdinal("userLastName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userName")))
                                        cust.userName = reader.GetString(reader.GetOrdinal("userName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPassword")))
                                        cust.userPassword = reader.GetString(reader.GetOrdinal("userPassword"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userEmail")))
                                        cust.userEmail = reader.GetString(reader.GetOrdinal("userEmail"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPhoneNumber")))
                                        cust.userPhoneNumber = reader.GetString(reader.GetOrdinal("userPhoneNumber"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userStreet")))
                                        cust.userStreet = reader.GetString(reader.GetOrdinal("userStreet"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userCity")))
                                        cust.userCity = reader.GetString(reader.GetOrdinal("userCity"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userState")))
                                        cust.userState = reader.GetString(reader.GetOrdinal("userState"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userZipcode")))
                                        cust.userZipcode = reader.GetInt32(reader.GetOrdinal("userZipcode"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userID")))
                                        cust.userID = reader.GetInt32(reader.GetOrdinal("userID"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPosition")))
                                        cust.userPosition = reader.GetString(reader.GetOrdinal("userPosition"));

                                    userList.Add(cust);
                                }
                            }
                        }
                    }
                }
                return (userList);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<UserDM> DisplayEmployee()
        {
            List<UserDM> userList = new List<UserDM>();
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand("EmployeeList", myConnection))
                    {
                        cmd.Connection = myConnection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var cust = new UserDM();
                                    if (!reader.IsDBNull(reader.GetOrdinal("userFirstName")))
                                        cust.userFirstName = reader.GetString(reader.GetOrdinal("userFirstName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userLastName")))
                                        cust.userLastName = reader.GetString(reader.GetOrdinal("userLastName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userName")))
                                        cust.userName = reader.GetString(reader.GetOrdinal("userName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPassword")))
                                        cust.userPassword = reader.GetString(reader.GetOrdinal("userPassword"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userEmail")))
                                        cust.userEmail = reader.GetString(reader.GetOrdinal("userEmail"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPhoneNumber")))
                                        cust.userPhoneNumber = reader.GetString(reader.GetOrdinal("userPhoneNumber"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userStreet")))
                                        cust.userStreet = reader.GetString(reader.GetOrdinal("userStreet"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userCity")))
                                        cust.userCity = reader.GetString(reader.GetOrdinal("userCity"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userState")))
                                        cust.userState = reader.GetString(reader.GetOrdinal("userState"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userZipcode")))
                                        cust.userZipcode = reader.GetInt32(reader.GetOrdinal("userZipcode"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userID")))
                                        cust.userID = reader.GetInt32(reader.GetOrdinal("userID"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPosition")))
                                        cust.userPosition = reader.GetString(reader.GetOrdinal("userPosition")); 

                                    userList.Add(cust);

                                }
                            }
                        }
                    }
                }
                return (userList);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<InventoryDM> DisplayInventory()
        {
            List<InventoryDM> inventoryList = new List<InventoryDM>();
            SqlConnection myConnection = new SqlConnection(ConnectionString);
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    myConnection.Open();
                    using (SqlCommand cmd = new SqlCommand("DisplayInventory", myConnection))
                    {
                        cmd.Connection = myConnection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var cust = new InventoryDM();

                                    if (!reader.IsDBNull(reader.GetOrdinal("inventoryID")))
                                        cust.inventoryID = reader.GetInt32(reader.GetOrdinal("inventoryID"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("inventoryName")))
                                        cust.inventoryName = reader.GetString(reader.GetOrdinal("inventoryName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("inventoryPrice")))
                                        cust.inventoryPrice = reader.GetDecimal(reader.GetOrdinal("inventoryPrice"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("inventoryStock")))
                                        cust.inventoryStock = reader.GetInt32(reader.GetOrdinal("inventoryStock"));

                                    inventoryList.Add(cust);
                                }
                            }
                        }
                    }
                }
                return (inventoryList);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public void UpdateUser(UserDM user)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateUser", myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userFirstName", user.userFirstName);
                        cmd.Parameters.AddWithValue("@userLastName", user.userLastName);
                        cmd.Parameters.AddWithValue("@userName", user.userName);
                        cmd.Parameters.AddWithValue("@userPassword", user.userPassword);
                        cmd.Parameters.AddWithValue("@userEmail", user.userEmail);
                        cmd.Parameters.AddWithValue("@userPhoneNumber", user.userPhoneNumber);
                        cmd.Parameters.AddWithValue("@userStreet", user.userStreet);
                        cmd.Parameters.AddWithValue("@userCity", user.userCity);
                        cmd.Parameters.AddWithValue("@userState", user.userState);
                        cmd.Parameters.AddWithValue("@userZipcode", user.userZipcode);
                        cmd.Parameters.AddWithValue("@userID", user.userID);
                        cmd.Parameters.AddWithValue("@userPosition", user.userPosition);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void UpdateInventory(InventoryDM user)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateInventory", myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@inventoryName", user.inventoryName);
                        cmd.Parameters.AddWithValue("@inventoryPrice", user.inventoryPrice);
                        cmd.Parameters.AddWithValue("@inventoryStock", user.inventoryStock);
                        cmd.Parameters.AddWithValue("@inventoryID", user.inventoryID);
                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public UserDM GetUserInfoByUserID(int id)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetUserInfoByUserID", myConnection))
                    {
                        myConnection.Open();
                        var cust = new UserDM();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userID", id);
                        List<UserDM> userList = new List<UserDM>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal("userFirstName")))
                                        cust.userFirstName = reader.GetString(reader.GetOrdinal("userFirstName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userLastName")))
                                        cust.userLastName = reader.GetString(reader.GetOrdinal("userLastName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userName")))
                                        cust.userName = reader.GetString(reader.GetOrdinal("userName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPassword")))
                                        cust.userPassword = reader.GetString(reader.GetOrdinal("userPassword"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userEmail")))
                                        cust.userEmail = reader.GetString(reader.GetOrdinal("userEmail"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPhoneNumber")))
                                        cust.userPhoneNumber = reader.GetString(reader.GetOrdinal("userPhoneNumber"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userStreet")))
                                        cust.userStreet = reader.GetString(reader.GetOrdinal("userStreet"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userCity")))
                                        cust.userCity = reader.GetString(reader.GetOrdinal("userCity"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userState")))
                                        cust.userState = reader.GetString(reader.GetOrdinal("userState"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userZipcode")))
                                        cust.userZipcode = reader.GetInt32(reader.GetOrdinal("userZipcode"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userID")))
                                        cust.userID = reader.GetInt32(reader.GetOrdinal("userID"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPosition")))
                                        cust.userPosition = reader.GetString(reader.GetOrdinal("userPosition"));
                                }
                            }
                        }
                        return (cust);
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public InventoryDM GetInventoryInfoByInventoryID(int id)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetInventoryInfoByInventoryID", myConnection))
                    {
                        myConnection.Open();
                        var cust = new InventoryDM();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@inventoryID", id);
                        List<InventoryDM> inventoryList = new List<InventoryDM>();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    if (!reader.IsDBNull(reader.GetOrdinal("inventoryID")))
                                        cust.inventoryID = reader.GetInt32(reader.GetOrdinal("inventoryID"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("inventoryName")))
                                        cust.inventoryName = reader.GetString(reader.GetOrdinal("inventoryName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("inventoryPrice")))
                                        cust.inventoryPrice = reader.GetDecimal(reader.GetOrdinal("inventoryPrice"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("inventoryStock")))
                                        cust.inventoryStock = reader.GetInt32(reader.GetOrdinal("inventoryStock"));

                                    inventoryList.Add(cust);
                                }
                            }
                        }
                        return (cust);
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public UserDM GetUserInfoByNameandPass(string userName, string pass)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetUserInfoByNameandPass", myConnection))
                    {
                        myConnection.Open();
                        var cust = new UserDM();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue(@"userPassword", pass);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    if (!reader.IsDBNull(reader.GetOrdinal("userID")))
                                        cust.userID = reader.GetInt32(reader.GetOrdinal("userID"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userName")))
                                        cust.userName = reader.GetString(reader.GetOrdinal("userName"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPassword")))
                                        cust.userPassword = reader.GetString(reader.GetOrdinal("userPassword"));

                                    if (!reader.IsDBNull(reader.GetOrdinal("userPosition")))
                                        cust.userPosition = reader.GetString(reader.GetOrdinal("userPosition"));
                                }
                            }
                        }

                        return (cust);
                    }
                }
            }

            catch (Exception e)
            {
                return null;
            }
        }

        public void DeleteUser(UserDM user)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteUser", myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@userName", user.userName);
                        cmd.Parameters.AddWithValue("@userPassword", user.userPassword);
                        cmd.Parameters.AddWithValue("@userStreet", user.userStreet);
                        cmd.Parameters.AddWithValue("@userCity", user.userCity);
                        cmd.Parameters.AddWithValue("@userState", user.userState);
                        cmd.Parameters.AddWithValue("@userZipcode", user.userZipcode);
                        cmd.Parameters.AddWithValue("@userID", user.userID);
                        cmd.Parameters.AddWithValue("@userID", user.userID);
                        cmd.Parameters.AddWithValue("@userPosition", user.userPosition);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void DeleteInventory(InventoryDM user)
        {
            try
            {
                using (SqlConnection myConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteInventory", myConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@inventoryName", user.inventoryName);
                        cmd.Parameters.AddWithValue("@inventoryPrice", user.inventoryPrice);
                        cmd.Parameters.AddWithValue("@inventoryStock", user.inventoryStock);

                        myConnection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
