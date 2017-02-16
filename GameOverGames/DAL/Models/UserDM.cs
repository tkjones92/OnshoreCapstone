using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class UserDM
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


    }
}
