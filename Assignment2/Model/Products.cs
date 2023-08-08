using System.ComponentModel.DataAnnotations;

namespace Assignment2.Model
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        [Required]
        public int SupplierID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public Suppliers Supplier { get; set; }
        public Categories Category { get; set; }
        public float QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public String ProductImage { get; set; }
    }
}
