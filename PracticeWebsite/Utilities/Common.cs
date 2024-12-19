using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PracticeWebsite.Models;
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
        public string ActiveUsername { get; set; }
        private int? ActiveUserID;
        public bool IsLoggedIn { get; set; }

        public string CurrentUsername { get; set; }

        // Logic for login, logout, and registration...
        public void Logout()
        {
            IsLoggedIn = false;
            CurrentUsername = string.Empty;
            ActiveUserID = null;
        }
    }
    public class PageService
    {
        private readonly TlS2301171RzaContext _context;

        public PageService(TlS2301171RzaContext context)
        {
            _context = context;
        }

        // Method to track page views
        //public async Task TrackPageViewAsync(string pageUrl)
        //{
        //    Console.WriteLine(pageUrl);
        //    var pageStats = await _context.Stats
        //        .SingleOrDefaultAsync(ps => ps.PageUrl == pageUrl);

        //    if (pageStats == null)
        //    {
        //        Console.WriteLine("New Page Entry");
        //    }
        //    else
        //    {
        //        // If the page exists, increment the Page_views by 1
        //        pageStats.PageViews++;
        //    }

        //    await _context.SaveChangesAsync();
        //}

        //// Get the total active user count from the database
        //public async Task<int> GetActiveUserCountAsync()
        //{
        //    // Query to get the total number of customers (active users)
        //    return await _context.Customers.CountAsync();
        //}

        //// Get the total page views from the 'Stats' table
        //public async Task<int> GetPageViewsCountAsync()
        //{
        //    // Sum up all PageViews in the Stats table
        //    return await _context.Stats.SumAsync(s => s.PageViews);
        //}

        //// Randomly generate new users count (kept as is)
        //public Task<int> GetNewUserCountAsync()
        //{
        //    return Task.FromResult(new Random().Next(5, 100)); // Generates a number between 5 and 100
        //}

        //public async Task Dispose()
        //{
        //    await _context.SaveChangesAsync();
        //}

    }
}
