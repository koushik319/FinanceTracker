using Microsoft.EntityFrameworkCore;
using FinanceTracker.Models;

namespace FinanceTracker.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Seed();

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
       
        public DbSet<Expense> Expenses { get; set; }





    }
}
