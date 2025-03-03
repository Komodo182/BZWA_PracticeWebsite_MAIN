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

        public async Task<List<Quiz>> GetQuizzes(int KeyStage, int subject)
        {
            return await _context.Quizzes.Where(q => q.KeystageId == KeyStage && q.SubjectId == subject).ToListAsync();
        }

        public async Task<List<Question>> GetQuestions(int QuizId)
        {
            return await _context.Questions.Where(q => q.QuizId == QuizId).ToListAsync();
        }
        public async Task<quiz> GetQuizData(int QuizId)
        {
            var questions = await _context.Questions
                .Where(q => q.QuizId == QuizId)
                .Take(3) // Assuming you want only 3 questions max
                .ToListAsync();

            if (questions.Count < 3) return new quiz(); // Ensure we don't get errors

            return new quiz
            {
                Quiz1Question = questions[0].Question1,
                Quiz1Ans1 = questions[0].Answer1,
                Quiz1Ans2 = questions[0].Answer2,
                Quiz1Ans3 = questions[0].Answer3,
                Quiz1Ans4 = questions[0].Answer4,

                Quiz2Question = questions[1].Question1,
                Quiz2Ans1 = questions[1].Answer1,
                Quiz2Ans2 = questions[1].Answer2,
                Quiz2Ans3 = questions[1].Answer3,
                Quiz2Ans4 = questions[1].Answer4,

                Quiz3Question = questions[2].Question1,
                Quiz3Ans1 = questions[2].Answer1,
                Quiz3Ans2 = questions[2].Answer2,
                Quiz3Ans3 = questions[2].Answer3,
                Quiz3Ans4 = questions[2].Answer4,
            };
        }
        public class quiz
        {
            public string Quiz1Question { get; set; }
            public string Quiz1Ans1 { get; set; }
            public string Quiz1Ans2 { get; set; }
            public string Quiz1Ans3 { get; set; }
            public string Quiz1Ans4 { get; set; }

            public string Quiz2Question { get; set; }
            public string Quiz2Ans1 { get; set; }
            public string Quiz2Ans2 { get; set; }
            public string Quiz2Ans3 { get; set; }
            public string Quiz2Ans4 { get; set; }

            public string Quiz3Question { get; set; }
            public string Quiz3Ans1 { get; set; }
            public string Quiz3Ans2 { get; set; }
            public string Quiz3Ans3 { get; set; }
            public string Quiz3Ans4 { get; set; }
        }
    }
}