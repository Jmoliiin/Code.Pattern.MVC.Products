using Code.Pattern.Products.Data;
using Code.Pattern.Products.Models.BaseModels;
using Code.Pattern.Products.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Code.Pattern.Products.Repositorys
{
    public interface ICategoryRepository
    {
        Task<ProductCategoryEntity> GetCategoryByIdAsync(int id);
        Task<IEnumerable<ProductCategoryEntity>> GetAllCategoryAsync();
        Task CreateCategoryAsync( ProductCategoryEntity categoryEntity);
        Task DeleteCategoryAsync(int id);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlContext _sqlContext;

        public CategoryRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task CreateCategoryAsync(ProductCategoryEntity categoryEntity)
        {
            try
            {
                _sqlContext.ProductCategories.Add(categoryEntity);
                await _sqlContext.SaveChangesAsync();
            }catch(Exception ex) { }  
        }

        public Task DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductCategoryEntity>> GetAllCategoryAsync()
        {
            return (await _sqlContext.ProductCategories.ToListAsync());
        }

        public Task<ProductCategoryEntity> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
