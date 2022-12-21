using Code.Pattern.Products.Factorys;
using Code.Pattern.Products.Models;
using Code.Pattern.Products.Models.Admin.CreateModels;
using Code.Pattern.Products.Repositorys;

namespace Code.Pattern.Products.Handler
{
    public interface ICategoryHandler
    {
        CreateCategoryModel CreateCategory();
        Task CreateCategoryAsync(CreateCategoryModel model);
        //Task<IEnumerable<CategoryModel>> GetAllCategorysAsync();
        //Task<CategoryModel> GetCategoryByIdAsync(int id);
        //Task<CategoryModel> GetCategoryByNameAsync(string name);


    }
    public class CategoryHandler : ICategoryHandler
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryFactory _categoryFactory;

        public CategoryHandler(ICategoryFactory categoryFactory, ICategoryRepository categoryRepository)
        {
            _categoryFactory = categoryFactory;
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(CreateCategoryModel model)
        {
            var categoryentity = _categoryFactory.CategoryEntity(model);
            await _categoryRepository.CreateCategoryAsync(categoryentity);
        }

        public CreateCategoryModel CreateCategory()
        {
            return _categoryFactory.CreateCategory();
        }

        //public Task<IEnumerable<CategoryModel>> GetAllCategorysAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<CategoryModel> GetCategoryByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<CategoryModel> GetCategoryByNameAsync(string name)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
