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
                .Take(10) // Assuming you want only 3 questions max
                .ToListAsync();

            if (questions.Count < 10) return new quiz(); // Ensure we don't get errors

            return new quiz
            {
                Quiz1Question = questions[0].Question1,
                Quiz1Ans1 = questions[0].Answer1,
                Quiz1Ans2 = questions[0].Answer2,
                Quiz1Ans3 = questions[0].Answer3,
                Quiz1Ans4 = questions[0].Answer4,
                Quiz1TrueAns = questions[0].Finalanswer,

                Quiz2Question = questions[1].Question1,
                Quiz2Ans1 = questions[1].Answer1,
                Quiz2Ans2 = questions[1].Answer2,
                Quiz2Ans3 = questions[1].Answer3,
                Quiz2Ans4 = questions[1].Answer4,
                Quiz2TrueAns = questions[1].Finalanswer,

                Quiz3Question = questions[2].Question1,
                Quiz3Ans1 = questions[2].Answer1,
                Quiz3Ans2 = questions[2].Answer2,
                Quiz3Ans3 = questions[2].Answer3,
                Quiz3Ans4 = questions[2].Answer4,
                Quiz3TrueAns = questions[2].Finalanswer,

                Quiz4Question = questions[3].Question1,
                Quiz4Ans1 = questions[3].Answer1,
                Quiz4Ans2 = questions[3].Answer2,
                Quiz4Ans3 = questions[3].Answer3,
                Quiz4Ans4 = questions[3].Answer4,
                Quiz4TrueAns = questions[3].Finalanswer,

                Quiz5Question = questions[4].Question1,
                Quiz5Ans1 = questions[4].Answer1,
                Quiz5Ans2 = questions[4].Answer2,
                Quiz5Ans3 = questions[4].Answer3,
                Quiz5Ans4 = questions[4].Answer4,
                Quiz5TrueAns = questions[4].Finalanswer,

                Quiz6Question = questions[5].Question1,
                Quiz6Ans1 = questions[5].Answer1,
                Quiz6Ans2 = questions[5].Answer2,
                Quiz6Ans3 = questions[5].Answer3,
                Quiz6Ans4 = questions[5].Answer4,
                Quiz6TrueAns = questions[5].Finalanswer,

                Quiz7Question = questions[6].Question1,
                Quiz7Ans1 = questions[6].Answer1,
                Quiz7Ans2 = questions[6].Answer2,
                Quiz7Ans3 = questions[6].Answer3,
                Quiz7Ans4 = questions[6].Answer4,
                Quiz7TrueAns = questions[6].Finalanswer,

                Quiz8Question = questions[7].Question1,
                Quiz8Ans1 = questions[7].Answer1,
                Quiz8Ans2 = questions[7].Answer2,
                Quiz8Ans3 = questions[7].Answer3,
                Quiz8Ans4 = questions[7].Answer4,
                Quiz8TrueAns = questions[7].Finalanswer,

                Quiz9Question = questions[8].Question1,
                Quiz9Ans1 = questions[8].Answer1,
                Quiz9Ans2 = questions[8].Answer2,
                Quiz9Ans3 = questions[8].Answer3,
                Quiz9Ans4 = questions[8].Answer4,
                Quiz9TrueAns = questions[8].Finalanswer,

                Quiz10Question = questions[9].Question1,
                Quiz10Ans1 = questions[9].Answer1,
                Quiz10Ans2 = questions[9].Answer2,
                Quiz10Ans3 = questions[9].Answer3,
                Quiz10Ans4 = questions[9].Answer4,
                Quiz10TrueAns = questions[9].Finalanswer,

            };
        }
    }
}