using Code.Pattern.Products.Data;
using Code.Pattern.Products.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Code.Pattern.Products.Repositorys
{
    public interface IDiscountRepository
    {
        Task <IEnumerable<DiscountEntity>> GetAllDiscountsAsync();
        Task CreateDiscountAsync(DiscountEntity discount);
    }

    public class DiscountRepository : IDiscountRepository
    {
        private readonly SqlContext _sqlContext;

        public DiscountRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task CreateDiscountAsync(DiscountEntity discount)
        {
            try
            {
                _sqlContext.Discount.Add(discount);
                await _sqlContext.SaveChangesAsync();
            }
            catch(Exception ex){  }
        }

        public async Task<IEnumerable<DiscountEntity>> GetAllDiscountsAsync()
        {
            return (await _sqlContext.Discount.ToListAsync());
        }
    }
}
