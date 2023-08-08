using System.ComponentModel.DataAnnotations;

namespace Assignment2.Model
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }
        public string CompanyName { get; set;}
        public string Address { get; set;}
        public string Phone { get; set;}
    }
}
