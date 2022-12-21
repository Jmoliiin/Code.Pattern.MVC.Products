
using Code.Pattern.Products.Handler;
using Microsoft.AspNetCore.Mvc;


namespace Code.Pattern.Products.Controllers
{
    //Liskov substittution, äver från Controller
    public class HomeController : Controller
    {
        /*single responsibility, då dom endast hanterar deligering av "Befintliga uppgifter" till rätt vy
        Dependency Inversion Principle
        HomeController tar in tex IProductHandler(interface),Producthandler tar in IProductFactor (interface) och IProductRepository.
        Med andra ord är highlevel inte beroende av low-level utan av abstractions. 
        Dip. De är beroende av abstractions vilket gör det mer flexibelt

        Open Closed principal: productcontrollern är beroende av IProductHandlern interfacet,vilket tillåter att enkelt byta ut olika implementationer av IproductHandlern utan att ändra coden i controllern
        ProductHandlern är beroende av IProductFactory och IProductRepository interfaces, vilket låter dom enkelt buta ut implementationen också. Vilket förljer
        Open and Closed principal, tillåter att "extend" funktinaliteten av systemet utan att ändra befintliga coden.
         
        */
        private readonly IProductHandler _productHandler;
        
        public HomeController(IProductHandler productHandler)
        {
            _productHandler = productHandler;
        }

        public  async Task <IActionResult> Index()
        {
            var AllProducts = await _productHandler.GetAllProductsAsync();
            ViewBag.TakeLatestItems = 8;
            return View(AllProducts);
        }

        [HttpGet]
        [Route("Products/{categoryName?}")]
        public async Task<IActionResult> Products(string? categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                var AllProductsAndCategeorys = await _productHandler.GetAllProductsAndCategeorysAsync();
                ViewData["pageHeader"] = "All products";
                return View(AllProductsAndCategeorys);
            }
            else {

            var ProductByCategoryName = await _productHandler.GetProductByCategoryNameAsync(categoryName);
            ViewData["pageHeader"] = categoryName;
            return View(ProductByCategoryName);
            }
        }
        [Route("Products/Product/{id}")]
        public async Task<IActionResult> Details( int id)
        {
                var product = await _productHandler.GetProductByIdAsync(id);
                return View(product);
        }

    }
}