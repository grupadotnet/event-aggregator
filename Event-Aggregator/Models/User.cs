using System.ComponentModel.DataAnnotations;

namespace Event_Aggregator.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required(ErrorMessage = "Write phone number down")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number contain of letters only")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Write email down")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
    }
}
