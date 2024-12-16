using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace PracticeWebsite.Utilities
{
    public class RegisterAccountForm
    {

        [Required]
        [StringLength(15, ErrorMessage = "Length of the name can't be more than 15 characters long.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Length of the name can't be more than 20 characters long.")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Username length can't be more than 10 charcaters long.")]
        public string Username { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        public string Password2 { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "The postcode is invalid length.", MinimumLength = 8)]
        public string PostCode { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Invalid phone number length.", MinimumLength = 11)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Invalid date has been provided.")]
        public string DoB { get; set; }
        public bool employeeStatus { get; set; }
        [StringLength(12, ErrorMessage = "Please input your Employee identification code.", MinimumLength = 12)]
        public string EmployeeID { get; set; }
    }
    public class LogInForm
    {
        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
    public class UserSession
    {
        public int UserId { get; set; }
        private int? ActiveUserID;
        public bool IsLoggedIn { get; set; }

        public static string CurrentUsername { get; private set; } = string.Empty;

        // Logic for login, logout, and registration...
        public void Login(string username)
        {
            IsLoggedIn = true;
            CurrentUsername = username;
            ActiveUserID = UserId;
        }

        public void Logout()
        {
            IsLoggedIn = false;
            CurrentUsername = string.Empty;
            ActiveUserID = null;
        }
    }
}
