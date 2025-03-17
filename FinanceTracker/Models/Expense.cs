using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using FinanceTracker.Models;
namespace FinanceTracker.Models
{
    public class Expense
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Expense Id")]
        public int ExpenseId { get; set; }

        [Required]
        [DisplayName("UserId")]
        [ForeignKey("User Id")]
        public int UserId { get; set; }
        [Required]

        [DisplayName("CategoryId")]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Amount")]
        public double Amount { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime Date { get; set; }

       

        public virtual Category Category { get; set; }

        //  PARENT TABLE NAME : USER
        public virtual User User { get; set; }
    }
}
