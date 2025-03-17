using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FinanceTracker.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("User Id")]
        public int UserId { get; set; }
        [Required]
        //[StringLength(25)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        //[StringLength(25)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        //[RegularExpression(@"^[0-9]{10,15}$", ErrorMessage = "It must contain digit and -")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
       
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailId { get; set; }
        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9@]{7,15}$", ErrorMessage = "Password must meet requirements")]
        public string Password { get; set; }

        // CHILD TABLE NAME : Expenses
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
