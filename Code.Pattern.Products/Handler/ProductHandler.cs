using Code.Pattern.Products.Data;
using Code.Pattern.Products.Factorys;
using Code.Pattern.Products.Models;
using Code.Pattern.Products.Models.Admin.CreateModels;
using Code.Pattern.Products.Models.BaseModels;
using Code.Pattern.Products.Models.Entites;
using Code.Pattern.Products.Models.ViewModels;
using Code.Pattern.Products.Repositorys;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Code.Pattern.Products.Models.IProducModel;

namespace Code.Pattern.Products.Handler
{
    //Open and close principal.
    public interface IProductHandler
    {
        //Isp 
        CreateProductModel CreateProductAsync();
        Task CreateProductAsync(CreateProductModel model);
        Task<IEnumerable<BaseProductModel>> GetAllProductsAsync();
        Task<ProductListViewModel> GetAllProductsAndCategeorysAsync();
        Task <ProductModel> GetProductByIdAsync(int id);
        Task<ProductListViewModel> GetProductByCategoryNameAsync(string categoryName);
        //Task <IEnumerable<BaseProductModel>> GetLatestProductsAsync(int number);
        
    }
    //implementation of IProductHandler
    public class ProductHandler : IProductHandler
    {
        //dependency injection to inject an instance
        private readonly IProductFactory _ProductFactory;
        private readonly ICategoryFactory _CategoryFactory;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public ProductHandler(IProductFactory productFactory, IProductRepository productRepository, ICategoryRepository categoryRepository, ICategoryFactory categoryFactory, IDiscountRepository discountRepository, IInventoryRepository inventoryRepository)
        {
            _ProductFactory = productFactory;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _CategoryFactory = categoryFactory;
            _discountRepository = discountRepository;
            _inventoryRepository = inventoryRepository;
        }

        //Single responsibility. Jag valde även att skapa repositoies som ansvarar för databashämtningen.
        public async Task<ProductListViewModel> GetAllProductsAndCategeorysAsync()
        {
            //BaseProductModel model = new ProductModel { Id=2,ArticleNumber="sdgsg",ProductName="test1",ProductDescription="test1",ProductPrice=89};
            //ProductModel model2 = new ProductModel { Id = 3, ArticleNumber = "sdgsg", ProductName = "test2", ProductDescription = "test2", ProductPrice = 89 };

            //instans of productlist
            var productLists = _ProductFactory.BaseProductList();
            foreach (var product in await _productRepository.GetAllProductsAsync())
                productLists.Add(_ProductFactory.Product(product));

            //instans av categorilistan
            var categoryLists = _CategoryFactory.CategoryList();
            foreach (var category in await _categoryRepository.GetAllCategoryAsync())
                categoryLists.Add(_CategoryFactory.Category(category));

            //instans av en model som innehåller två listor-en productlist,encategorilista
            var modelview = _ProductFactory.BaseProductListView(productLists,categoryLists);

          return modelview;
        }
        public async Task<ProductListViewModel> GetProductByCategoryNameAsync( string categoryName)
        {
            //instans of productlist
            var productLists = _ProductFactory.BaseProductList();

            var productsEntites = await _productRepository.GetAllProductsAsync();
            //var selectedCategory = await _categoryRepository.GetCategoryAndProductsByNameAsync(categoryName);
            foreach (var product in productsEntites.Where(x=>x.ProductCategory.CategoryName==categoryName))
                productLists.Add(_ProductFactory.Product(product));

            
            //instans of categoryList
            var categoryLists = _CategoryFactory.CategoryList();
            foreach (var category in await _categoryRepository.GetAllCategoryAsync())
                categoryLists.Add(_CategoryFactory.Category(category));

            //instans of a model that has rwo lists- one productlist,one categoryList
            var modelview = _ProductFactory.BaseProductListView(productLists, categoryLists);

            return modelview;
        }

        public async Task<IEnumerable<BaseProductModel>> GetAllProductsAsync()
        {
            //IBaseProduct baseproduct = new ProductModel();
            //BaseProductModel bs = new ProductModel();
            //IProducModel bs2 = new ProductModel();
            //ProductModel bs3= new ProductModel();
            //baseproduct.PriceWithDiscount = 10;
            //bs.PriceWithDiscount = 10;
            //bs2.PriceWithDiscount = 10;
            //bs3.PriceWithDiscount = 10;


            //factory hanterar nya instanser enligt singelresponsibility principen och Dip 
            var productLists = _ProductFactory.BaseProductList();

            foreach (var product in await _productRepository.GetAllProductsAsync())
                productLists.Add(_ProductFactory.Product(product));

            return productLists;
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
                var productModel = _ProductFactory.Product(await _productRepository.GetProductByIdAsync(id));
                return productModel;
        }

        //public async Task<IEnumerable<BaseProductModel>> GetLatestProductsAsync(int number)
        //{
        //    var productLists = _ProductFactory.BaseProductList();
        //    foreach (var product in await _productRepository.GetAllProductsAsync())
        //        productLists.Add(_ProductFactory.Product(product));

        //    return productLists;
        //    //var returnList = productLists.TakeLast(number);
        //    //return returnList;
        //}

        public CreateProductModel CreateProductAsync()
        {
            var productModel = _ProductFactory.CreateProduct();
            return productModel;
        }

        public async Task CreateProductAsync(CreateProductModel model)
        {
            var categorys = await _categoryRepository.GetAllCategoryAsync(); //await _sqlContext.ProductCategories.Where(x => x.CategoryName == model.Category).FirstOrDefaultAsync();
                var categoryEntity = categorys.Where(x=>x.CategoryName==model.Category).First();

            var productEntity = _ProductFactory.ProductEntity();
            productEntity.ProductName = model.ProductName;
            productEntity.ProductDescription = model.ProductDescription;
            productEntity.ProductPrice = model.ProductPrice;
            productEntity.ProductCreated = DateTime.Now;
            productEntity.ArticleNumber = model.ArticleNumber;
            productEntity.ProductCategoryId = categoryEntity.Id;

            var discounts = await _discountRepository.GetAllDiscountsAsync(); 
            var discountEntity = discounts.Where(x=>x.Name==model.DiscountName).FirstOrDefault();

            productEntity.DiscountId = discountEntity.Id;

            var inventoryentities = await _inventoryRepository.GetAllInventoryAsync();
            var inventoryExist = inventoryentities.Where(x => x.Quantity == model.Quantity).FirstOrDefault();
            if (inventoryExist != null)
            {
                productEntity.ProductInventoryId = inventoryExist.Id;
            }
            else{
                //Här skapde jag aldrig en factory, vilket bordes göra. men då jag bara hanterar denna här nu. får den stanna tills jag hanterar fler av samma objekt
                var newInventory = new ProductInventoryEntity { Quantity = model.Quantity };
                await _inventoryRepository.CreateInventoryAsync(newInventory);
                productEntity.ProductInventoryId = newInventory.Id;
            }

            await _productRepository.CreateProductAsync(productEntity);
        }
    }
}
