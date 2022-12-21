using Code.Pattern.Products.Models.Entites;
using Code.Pattern.Products.Models;
using Code.Pattern.Products.Models.Admin;
using Code.Pattern.Products.Models.Admin.CreateModels;

namespace Code.Pattern.Products.Factorys
{
    public interface ICategoryFactory
    {
        ProductCategoryEntity CategoryEntity();
        ProductCategoryEntity CategoryEntity(CreateCategoryModel model);
        CreateCategoryModel CreateCategory();
        List<CategoryMenuModel> CategoryMenuList();
        CategoryMenuModel CategoryMenu(ProductCategoryEntity categoryEntity);
        List<CategoryModel> CategoryList();
        CategoryModel Category(ProductCategoryEntity categoryEntity);
    }
    public class CategoryFactory : ICategoryFactory
    {
        public List<CategoryModel> CategoryList()
        {
            return new List<CategoryModel>();
        }
        public CategoryModel Category(ProductCategoryEntity categoryEntity)
        {
            return new CategoryModel()
            {
                Id = categoryEntity.Id,
                CategoryName = categoryEntity.CategoryName
            };
        }

        public List<CategoryMenuModel> CategoryMenuList()
        {
            return new List<CategoryMenuModel>();
        }

        public CategoryMenuModel CategoryMenu(ProductCategoryEntity categoryEntity)
        {
            return new CategoryMenuModel() { CategoryName = categoryEntity.CategoryName, };
        }

        public ProductCategoryEntity CategoryEntity()
        {
            return new ProductCategoryEntity();
        }

        public ProductCategoryEntity CategoryEntity(CreateCategoryModel model)
        {
            return new ProductCategoryEntity() { CategoryName=model.CategoryName, };
        }

        public CreateCategoryModel CreateCategory()
        {
            return new CreateCategoryModel();
        }
    }
}
