using PracticeWebsite.Models;
namespace PracticeWebsite.Services
{
    public class CustomerServices
    {
        private readonly TlS2301171RzaContext _context;
        public CustomerServices(TlS2301171RzaContext context)
        {
            _context = context;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task LogInCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }
    }
}
