using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BLL.Models;
using GameOverGames;

namespace GameOverGames.Controllers
{
    public class UserVM
    {
        [Key]

        [Required(ErrorMessage = "First Name is Required")]
        public string userFirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string userLastName { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string userPassword { get; set; }

        [Compare("userPassword", ErrorMessage = "Please confirm your password")]
        [RegularExpression(@"^[a-zA-Z]\w{3,14}$", ErrorMessage = "The password's first character must be a letter, it must contain at least 4 characters and no more" +
                                                                "than 15 characters and no characters other than letters, numbers and the underscore may be used")]
        [DataType(DataType.Password)]
        public string ConfirmUserPassword { get; set; }


        [Required(ErrorMessage = "Email is Required")]
        public string userEmail { get; set; }

        [Compare("userEmail", ErrorMessage = "Please make sure your email mathces the one above")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Incorrect Format")]
        public string ConfirmUserEmail { get; set; }

        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Must be in (123) 456-7890 or 123-456-7890 format")]
        [Required(ErrorMessage = "Phone Number is Required")]
        public string userPhoneNumber { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string userStreet { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string userCity { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string userState { get; set; }

        [Required(ErrorMessage = "Zipcode is required")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Incorrect Format")]
        public int userZipcode { get; set; }

        public int userID { get; set; }
        public string userPosition { get; set; }


        public static UserVM Map(UserSM human) //Find a way to Map from one List to another List each object
        {
            UserVM User = new UserVM();
            User.userFirstName = human.userFirstName;
            User.userLastName = human.userLastName;
            User.userName = human.userName;
            User.userPassword = human.userPassword;
            User.ConfirmUserPassword = human.ConfirmUserPassword;
            User.userEmail = human.userEmail;
            User.ConfirmUserEmail = human.ConfirmUserEmail;
            User.userPhoneNumber = human.userPhoneNumber;
            User.userStreet = human.userStreet;
            User.userCity = human.userCity;
            User.userState = human.userState;
            User.userZipcode = human.userZipcode;
            User.userID = human.userID;
            User.userPosition = human.userPosition;
            return User;

        }
        public static UserSM Map(UserVM human)
        {
            UserSM User = new UserSM();
            User.userFirstName = human.userFirstName;
            User.userLastName = human.userLastName;
            User.userName = human.userName;
            User.userPassword = human.userPassword;
            User.ConfirmUserPassword = human.ConfirmUserPassword;
            User.userEmail = human.userEmail;
            User.ConfirmUserEmail = human.ConfirmUserEmail;
            User.userPhoneNumber = human.userPhoneNumber;
            User.userStreet = human.userStreet;
            User.userCity = human.userCity;
            User.userState = human.userState;
            User.userZipcode = human.userZipcode;
            User.userID = human.userID;
            User.userPosition = human.userPosition;
            return User;
        }

        public static List<UserSM> Map(List<UserVM> list) //Outside Main need static fields
        {
            List<UserSM> userList = new List<UserSM>();
            foreach (UserVM human in list)
            {
                userList.Add(Map(human));
            }
            return (userList);
        }

        public static List<UserVM> Map(List<UserSM> list)
        {
            List<UserVM> userList = new List<UserVM>();
            foreach (UserSM human in list)
            {
                userList.Add(Map(human));
            }
            return (userList);
        }
    }
}