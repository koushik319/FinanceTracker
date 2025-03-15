using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace FinanceTracker.Models
{
    public class Expense
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Expense Id")]
        public int ExpenseId { get; set; }

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
