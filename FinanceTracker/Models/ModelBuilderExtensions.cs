using Microsoft.EntityFrameworkCore;
using FinanceTracker.Models;
namespace FinanceTracker.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                           new User() { UserId = 1, FirstName = "Shiva", LastName = "Ram", PhoneNumber = "7891234567", EmailId = "shivaram@gmail.com", Password = "shiva@123" }

                           );
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Housing" },
                new Category() { CategoryId = 2, CategoryName = "Food" },
                new Category() { CategoryId = 3, CategoryName = "Transportation" },
                new Category() { CategoryId = 4, CategoryName = "Health" },
                new Category() { CategoryId = 5, CategoryName = "Kids" },
                new Category() { CategoryId = 6, CategoryName = "Opearting Expenses" }



                );

            //modelBuilder.Entity<Expense>().HasData(
            //    new Expense() { ExpenseId = 1, EmployeeId = 1, ITRoleId = 1, SkillName = "DOT NET CORE", ExperienceYears = 5 },
            //    new Expense() { ExpenseId = 2, EmployeeId = 1, ITRoleId = 5, SkillName = "AZ-204", ExperienceYears = 2 }

            //   );

        }
    }
}
