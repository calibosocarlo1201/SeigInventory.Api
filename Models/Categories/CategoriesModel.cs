using System.ComponentModel.DataAnnotations;

namespace Inventory.Api.Models.Categories
{
    public class CategoriesModel
    {
        [Key]
        public string CategoryID { get; set; } = String.Empty;
        public string CategoryName { get; set; } = String.Empty;
    }

    public class LatestCategoryID
    {
        [Key]
        public string CategoryID { get; set; } = String.Empty;
    }
}
