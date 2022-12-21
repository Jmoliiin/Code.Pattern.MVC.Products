using Code.Pattern.Products.Data;
using Code.Pattern.Products.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Code.Pattern.Products.Repositorys
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<ProductInventoryEntity>> GetAllInventoryAsync();
        Task CreateInventoryAsync(ProductInventoryEntity entity);
    }
    public class InventoryRepository : IInventoryRepository
    {
        private readonly SqlContext _sqlContext;

        public InventoryRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task CreateInventoryAsync(ProductInventoryEntity entity)
        {
            try
            {
                _sqlContext.ProductInventory.Add(entity);
                await _sqlContext.SaveChangesAsync();
            }
            catch(Exception ex) { }
            
        }

        public async Task<IEnumerable<ProductInventoryEntity>> GetAllInventoryAsync()
        {
            return (await _sqlContext.ProductInventory.ToListAsync());
        }
    }
}
