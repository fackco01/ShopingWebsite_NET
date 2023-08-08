using System.ComponentModel.DataAnnotations;

namespace Assignment2.Model
{
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ContactName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
