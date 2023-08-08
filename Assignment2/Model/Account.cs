using System.ComponentModel.DataAnnotations;

namespace Assignment2.Model
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Type { get; set; }

    }
}
