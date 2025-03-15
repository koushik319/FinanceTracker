using System.ComponentModel.DataAnnotations;
namespace FinanceTracker.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public string UserMessage { get; set; } = "Login Status";

        public string AccessToken { get; set; } = "space for token";

        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
