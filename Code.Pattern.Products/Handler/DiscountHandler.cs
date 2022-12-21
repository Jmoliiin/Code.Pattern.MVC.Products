using Code.Pattern.Products.Factorys;
using Code.Pattern.Products.Models;
using Code.Pattern.Products.Models.Admin.CreateModels;
using Code.Pattern.Products.Repositorys;

namespace Code.Pattern.Products.Handler
{
    public interface IDiscountHandler
    {
        CreateDiscountModel CreateDiscount();
        Task CreateDiscountAsync(CreateDiscountModel model);
    }
    public class DiscountHandler : IDiscountHandler
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IDiscountFactory _discountFactory;

        public DiscountHandler(IDiscountRepository discountRepository, IDiscountFactory discountFactory)
        {
            _discountRepository = discountRepository;
            _discountFactory = discountFactory;
        }

        public async Task CreateDiscountAsync(CreateDiscountModel model)
        {
            var discountentity = _discountFactory.DiscountEntity(model);
            await _discountRepository.CreateDiscountAsync(discountentity);
        }

        public CreateDiscountModel CreateDiscount()
        {
            var discountmodel = _discountFactory.CreateDiscount();
            return discountmodel;
        }
    }
}
