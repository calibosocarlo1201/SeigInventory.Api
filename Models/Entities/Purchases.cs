using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Api.Models.Entities
{
    public class Purchases
    {
        [Key]
        [MaxLength(20)]
        public string PurchaseID { get; set; } = String.Empty;
        [MaxLength(20)]
        public string ProductID { get; set; } = String.Empty;
        [MaxLength(20)]
        public string SupplierID {  get; set; } = String.Empty;
        [MaxLength(10)]
        public string PurchaseDate {  get; set; } = String.Empty;
        [Column(TypeName = "numeric(10,0)")]
        public decimal PurchaseQuantity { get; set; }
        [Column(TypeName = "numeric(10,2)")]
        public decimal UnitCost { get; set; }
        [Column(TypeName = "numeric(10,2)")]
        public decimal TotalCost { get; set; }

        public Products Products { get; set; }
        public Suppliers Suppliers { get; set; }

    }
}