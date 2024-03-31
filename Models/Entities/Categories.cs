using System.ComponentModel.DataAnnotations;

namespace Inventory.Api.Models.Entities
{
    public class Categories
    {
        [Key]
        [MaxLength(20)]
        public string CategoryID { get; set; } = String.Empty;
        [MaxLength(50)]
        public string CategoryName { get; set; } = String.Empty;

        public ICollection<Products> Products { get; set; }
    }
}
