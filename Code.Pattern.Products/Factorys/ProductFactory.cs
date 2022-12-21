using Code.Pattern.Products.Models;
using Code.Pattern.Products.Models.Admin.CreateModels;
using Code.Pattern.Products.Models.BaseModels;
using Code.Pattern.Products.Models.Entites;
using Code.Pattern.Products.Models.ViewModels;
using static Code.Pattern.Products.Models.IProducModel;

namespace Code.Pattern.Products.Factorys
{
    //DIP Factory som gör/sköter instansieringen av classer i projectet
    //Igentligen bör olika producter och categori separeras i olika Factorys. Jag valde dock att Lägga båda i IproductFactory För att göra detta project simplare. denna uppfyller inte single responibility 
    public interface IProductFactory
    {
        //Isp
        //Skickar ut en baseproductmodel i de som hanterar listor för att kunna hantera flera olika modeler som har baseproduct arvet
        CreateProductModel CreateProduct();
        ProductEntity ProductEntity();
        List<BaseProductModel> BaseProductList();
        ProductModel Product(ProductEntity productEntity);
        ProductListViewModel BaseProductListView(List<BaseProductModel> productList, List<CategoryModel> productcategoryList);
        CategoryAndAllProductListViewModel CategoryAndAllProductListView(List<BaseProductModel> productList, CategoryModel productCategory);
    }
    public class ProductFactory :IProductFactory
    {
        public List<BaseProductModel> BaseProductList()
        {
            return new List<BaseProductModel>();
        }
        public ProductModel Product(ProductEntity productEntity)
        {
            return new ProductModel()
            {
                Id = productEntity.Id,
                ProductName = productEntity.ProductName,
                ArticleNumber = productEntity.ArticleNumber,
                ProductDescription = productEntity.ProductDescription,
                ProductPrice = productEntity.ProductPrice,
                Category = productEntity.ProductCategory.CategoryName,
                Quantity = productEntity.ProductInventory.Quantity,
                DiscountAmount=productEntity.Discount.Amount,
                PriceWithDiscount=(productEntity.ProductPrice-productEntity.Discount.Amount)
            };
        } 
        public  ProductListViewModel BaseProductListView(List<BaseProductModel> productList, List<CategoryModel> productcategoryList)
        {
            return new ProductListViewModel() 
            {
                ProductList = productList,
                CategoryList = productcategoryList
            };
        }

        public CategoryAndAllProductListViewModel CategoryAndAllProductListView(List<BaseProductModel> productList, CategoryModel productCategory)
        {
            return new CategoryAndAllProductListViewModel()
            {
                ProductList = productList,
                CategoryModel=productCategory  
            };
        }

        public CreateProductModel CreateProduct()
        {
            return new CreateProductModel();
        }

        public ProductEntity ProductEntity()
        {
            return new ProductEntity();
        }
    }

   
}
