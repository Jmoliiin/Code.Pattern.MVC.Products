using Code.Pattern.Products.Data;
using Code.Pattern.Products.Models;
using Code.Pattern.Products.Models.BaseModels;
using Code.Pattern.Products.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Code.Pattern.Products.Repositorys
{
    //ProductRepository that provides methods for querying and modifying products in the database
    public interface IProductRepository
    {
        Task <ProductEntity> GetProductByIdAsync(int id);
        Task CreateProductAsync(ProductEntity productEntity);
        Task <IEnumerable<ProductEntity>> GetAllProductsAsync();
        Task DeleteProductAsync(int id);

    }
    public class ProductRepository : IProductRepository
    {
        private readonly SqlContext _SqlContext;

        public ProductRepository(SqlContext sqlContext)
        {
            _SqlContext = sqlContext;
        }

        //public async Task UpdateProductPriceAsync(ProducModel model)
        //{
        //    var entity = await _SqlContext.ProductEntities.FirstOrDefaultAsync(x=>x.Id==model.Id);
        //    if (entity != null)
        //    {
        //        try
        //        {
        //            entity.ProductPrice = model.ProductPrice;
        //            _SqlContext.Update(entity);
        //            await _SqlContext.SaveChangesAsync();
        //        }catch(Exception ex) { }
        //    }
            
        //}
        public async Task CreateProductAsync(ProductEntity productEntity)
        {
            try
            {
                _SqlContext.ProductEntities.Add(productEntity);
                await _SqlContext.SaveChangesAsync();
            }catch(Exception ex){ }
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
        {
            return (await _SqlContext.ProductEntities.Include(x => x.ProductCategory).Include(x => x.ProductInventory).Include(x=>x.Discount).ToListAsync());
        }

        public async Task <ProductEntity> GetProductByIdAsync(int id)
        {
         return (await _SqlContext.ProductEntities.Include(x => x.ProductCategory).Include(x => x.ProductInventory).Include(x=>x.Discount).FirstOrDefaultAsync(x => x.Id == id));   
        }
    }
}
