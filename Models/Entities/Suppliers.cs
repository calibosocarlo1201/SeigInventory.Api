using System.ComponentModel.DataAnnotations;

namespace Inventory.Api.Models.Entities
{
    public class Suppliers
    {
        [Key]
        [MaxLength(20)]
        public string SupplierID { get; set; } = String.Empty;
        [MaxLength(50)]
        public string SupplierName { get; set; } = String.Empty;
        [MaxLength(50)]
        public string ContactName { get; set;} = String.Empty;
        [MaxLength(50)]
        public string ContactTitle { get; set;} = String.Empty;
        [MaxLength(50)]
        public string Address { get; set;} = String.Empty;
        [MaxLength(50)]
        public string City { get; set;} = String.Empty;
        [MaxLength(50)]
        public string Region { get; set;} = String.Empty;
        [MaxLength(50)]
        public string PostalCode { get; set; } = String.Empty;
        [MaxLength(50)]
        public string Country { get; set; } = String.Empty;
        [MaxLength(50)]
        public string Phone { get; set; } = String.Empty;
        [MaxLength(50)]
        public string Email { get; set; } = String.Empty;   

        public ICollection<Products> Products { get; set; }
    }
}
