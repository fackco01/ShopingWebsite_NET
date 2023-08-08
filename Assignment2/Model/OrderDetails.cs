using System.ComponentModel.DataAnnotations;

namespace Assignment2.Model
{
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public ICollection<Products> Products { get; set; } 
        public Orders Order { get; set; }
    }
}
