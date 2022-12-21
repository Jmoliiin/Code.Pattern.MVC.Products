using Code.Pattern.Products.Data;
using Code.Pattern.Products.Factorys;
using Code.Pattern.Products.Models.Admin;
using Code.Pattern.Products.Models.Entites;
using Code.Pattern.Products.Repositorys;

namespace Code.Pattern.Products.Handler
{
    public interface IHelperHandler
    {
        Task <List<CategoryMenuModel>> CategoryMenuAsync();
        Task <List<DiscountMenuModel>> DiscountMenuAsync();
        Task AddDefaultDiscount(string DefaultName);
    }
    public class HelperHandler : IHelperHandler
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IDiscountFactory _discountFactory;
        private readonly ICategoryFactory _categoryFactory;
        private readonly ICategoryRepository _categoryRepository;

        public HelperHandler(IDiscountFactory discountFactory, IDiscountRepository discountRepository, ICategoryRepository categoryRepository, ICategoryFactory categoryFactory)
        {
            _discountFactory = discountFactory;
            _discountRepository = discountRepository;
            _categoryRepository = categoryRepository;
            _categoryFactory = categoryFactory;
        }

        public async Task AddDefaultDiscount(string defaultName)
        {
            //create a default no sicount property in database
            var defaultExist = await _discountRepository.GetAllDiscountsAsync();
            //var discountExist = defaultExist.Where(x => x.Name == defaultName);
            
                if (!defaultExist.Any())
                {
                    var newDiscount = _discountFactory.DiscountEntity(); 
                    newDiscount.Name = defaultName;
                    newDiscount.Amount = 0;

                    await _discountRepository.CreateDiscountAsync(newDiscount);
                    
                }
            
                
        }
        public async Task<List<CategoryMenuModel>> CategoryMenuAsync()
        {
            var list = _categoryFactory.CategoryMenuList();
            foreach (var category in await _categoryRepository.GetAllCategoryAsync())
                list.Add(_categoryFactory.CategoryMenu(category));
            return list;
        }

        public async Task<List<DiscountMenuModel>> DiscountMenuAsync()
        {
            
            var list = _discountFactory.DiscountList();
            foreach (var discount in await _discountRepository.GetAllDiscountsAsync())
                list.Add(_discountFactory.DiscountMenu(discount));
            return list;
        }
        
    }

}
