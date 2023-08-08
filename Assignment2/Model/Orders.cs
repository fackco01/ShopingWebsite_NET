using System.ComponentModel.DataAnnotations;

namespace Assignment2.Model
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
        [Required]
        public int CustomerID { get; set; }
        public Customers Customer { get; set; }
        public ICollection<OrderDetails> Details { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public float Freight { get; set; } 
        public string ShipAddress { get; set; }
    }
}
