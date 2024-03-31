using Inventory.Api.Data;
using Inventory.Api.Models;
using Inventory.Api.Models.Categories;
using Inventory.Api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly InventoryDbContext _dbContext;
        readonly ResultModel results = new();

        public CategoriesController(InventoryDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<CategoriesModel>>> GetCategoryList()
        {

            var categories = await _dbContext.Categories
                 .Select(c => new CategoriesModel
                 {
                     CategoryID = c.CategoryID,
                     CategoryName = c.CategoryName,
                 })
                 .ToListAsync();

            //if (categories == null || !categories.Any())
            //{
            //    return NotFound();
            //}

            return categories;
        }

        [HttpGet("LatestCategoryID/Get")]
        public async Task<ActionResult<string>> GetLatestCategoryID()
        {

            string newCategoryID;

            bool isEmpy = !_dbContext.Categories.Any();

            if (isEmpy)
            {
                newCategoryID = "0000000001";
            }
            else
            {
                string maxCategoryID = await _dbContext.Categories.MaxAsync(c => c.CategoryID);
                int nextCategoryID = int.Parse(maxCategoryID) + 1;
                newCategoryID = nextCategoryID.ToString("D10");
            }

            return newCategoryID;

        }

        [HttpPost("Post")]
        public async Task<ResultModel> AddCategory(CategoriesModelInput _data)
        {

            string newCategoryID;

            bool isEmpy = !_dbContext.Categories.Any();

            if (isEmpy)
            {
                newCategoryID = "0000000001";
            }
            else
            {
                string maxCategoryID = await _dbContext.Categories.MaxAsync(c => c.CategoryID);
                int nextCategoryID = int.Parse(maxCategoryID) + 1;
                newCategoryID = nextCategoryID.ToString("D10");
            }

            try
            {

                Categories categ = new Categories
                {
                    CategoryID = newCategoryID,
                    CategoryName = _data.CategoryName,
                };

                await _dbContext.Categories.AddAsync(categ);
                await _dbContext.SaveChangesAsync();

                results.Message = "Category: " + newCategoryID + " has been successfully added.";
                results.Success = true;

            } catch (DbUpdateException ex)
            {
                results.Success = false;
                results.Message = ex.Message;
            }
            catch (Exception ex)
            {
                results.Success = false;
                results.Message = "Something went wrong. " + ex.Message;
            }

            return results;
        }

        [HttpPut("Update/{_data.CategoryID}")]
        public async Task<ActionResult<ResultModel>> UpdateCategory(CategoriesModel _data)
        {

            try
            {

                var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryID == _data.CategoryID);
                if (category == null)
                {
                    return NotFound();
                }

                category.CategoryName = _data.CategoryName;

                _dbContext.Categories.Update(category);
                await _dbContext.SaveChangesAsync();

                results.Message = "Category: " + _data.CategoryID + " has been successfully updated.";
                results.Success = true;

            }
            catch (DbUpdateException ex)
            {
                results.Success = false;
                results.Message = ex.Message;
            }
            catch (Exception ex)
            {
                results.Success = false;
                results.Message = "Something went wrong. " + ex.Message;
            }

            return results;
        }
    }
}
