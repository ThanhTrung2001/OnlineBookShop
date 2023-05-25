using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.Models
{
    public abstract class Account
    {
        [Required]
        [Key]
        public int AccountID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string CitizenID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
