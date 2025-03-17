using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinanceTracker.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Category Id")]
        public int CategoryId { get; set; }
        [Required]
        //[StringLength(25)]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        //CHILD TABLE NAME : Expense 
        public virtual ICollection<Expense> Expenses { get; set; }

    }
}
