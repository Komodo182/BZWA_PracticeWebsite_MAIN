using PracticeWebsite.Models;
using Microsoft.EntityFrameworkCore;
using PracticeWebsite.Utilities;
namespace PracticeWebsite.Services

{
    public class CustomerServices
    {
        private readonly TlS2301171RzaContext _context;
        public CustomerServices(TlS2301171RzaContext context)
        {
            _context = context;
        }
        public async Task AddCustomerAsync(RegisterAccountForm customer)
        {
            Customer _customer = new Customer();
            _customer.Username = customer.Username;
            _customer.Password = customer.Password;
            _customer.FirstName = customer.FirstName;
            _customer.LastName = customer.LastName;
            _customer.Email = customer.Email;
            _customer.PhoneNumber = customer.PhoneNumber;
            _customer.Postcode = customer.PostCode;
            _customer.DateOfBirth = DateOnly.Parse(customer.DoB);
            _customer.EmployeeId = customer.EmployeeID;

            await _context.Customers.AddAsync(_customer);
            await _context.SaveChangesAsync();
        }
        public async Task LogInCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }
        public async Task<bool> CheckUsernameExistsAsync(string Username)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Username == Username);
            return result != null;
        }
        public async Task<Customer?> LogIn(Customer customer)
        {
            return await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == customer.Username &&
                c.Password == customer.Password);
        }
    }
}
