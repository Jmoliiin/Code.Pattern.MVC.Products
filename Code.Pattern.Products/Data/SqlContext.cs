using Code.Pattern.Products.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Code.Pattern.Products.Data
{
    public class SqlContext : DbContext

    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet <ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet <ProductInventoryEntity> ProductInventory { get; set; }
        public DbSet<DiscountEntity> Discount { get; set; }
        
    }
}
