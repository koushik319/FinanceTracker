using Microsoft.EntityFrameworkCore;
using FinanceTracker.Models;

namespace FinanceTracker.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, FirstName = "Shiva", LastName = "Ram", PhoneNumber = "7891234567", EmailId = "shivaram@gmail.com", Password = "shiva@123" },
                new User() { UserId = 2, FirstName = "Koushik", LastName = "B", PhoneNumber = "9087654321", EmailId = "koushik123@gmail.com", Password = "koushik@123" }
            );

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1,CategoryName = "Housing" },   
                new Category() { CategoryId = 2,CategoryName = "Food" },    
                new Category() { CategoryId = 3,CategoryName = "Transportation" }, 
                new Category() { CategoryId = 4, CategoryName = "Health" },    
                new Category() { CategoryId = 5,CategoryName = "Kids" },     
                new Category() { CategoryId = 6,CategoryName = "Operating Expenses" }  
            );

            
            modelBuilder.Entity<Expense>().HasData(
                new Expense() {ExpenseId=1,UserId = 1, CategoryId = 1, Description = "House Rent", Amount = 10000, Date = DateTime.Now },
                new Expense() {ExpenseId=2, UserId = 2, CategoryId = 5, Description = "Restaurants", Amount = 4000, Date = DateTime.Now } 
            );
        }
    }
}
