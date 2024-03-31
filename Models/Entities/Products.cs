using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Api.Models.Entities
{
    public class Products
    {
        [Key]
        [MaxLength(20)]
        public string ProductID { get; set; } = String.Empty;
        [MaxLength(50)]
        public string ProductName { get; set; } = String.Empty;
        [MaxLength(200)]
        public string Description { get; set; } = String.Empty;
        [MaxLength(20)]
        public string CategoryID { get; set; } = String.Empty;
        [MaxLength(20)]
        public string SupplierID { get; set; } = String.Empty;
        [Column(TypeName = "numeric(10,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "numeric(10,0)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "numeric(10,0)")]
        public decimal ReOrderLevel { get; set; }
        [MaxLength(10)]
        public string LastStockedDate { get; set; } = String.Empty;

        // Navigation Properties
        public Categories Categories { get; set; }
        public Suppliers Suppliers { get; set; }
    }
}
