using Code.Pattern.Products.Data;
using Code.Pattern.Products.Factorys;
using Code.Pattern.Products.Handler;
using Code.Pattern.Products.Models.Admin;
using Code.Pattern.Products.Models.Admin.CreateModels;
using Code.Pattern.Products.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;

namespace Code.Pattern.Products.Controllers
{
    /*Denna controller följer inte single responsibility principen, 
     Här borde man seperera controllers i :admin ,products,category,discount.
     För enkelhetens skull , lade jag dessa i samma controller.

    Därimot följer varje component i controllern single responsibility, då dom endast hanterar deligering av "Befintliga uppgifter" till rätt vy.

     */
    public class AdminController : Controller
    {
        /*Dependency Inversion Principle
         AdminController tar in tex IProductHandler(interface),Producthandler tar in IProductFactor (interface) och IProductRepository.
        Med andra ord är highlevel inte beroende av low-level utan av abstractions.
        Dip. De är beroende av abstractions vilket gör det mer flexibelt

        Open Closed principal: productcontrollern är beroende av IProductHandlern interfacet,vilket tillåter att enkelt byta ut olika implementationer av IproductHandlern utan att ändra coden i controllern
        ProductHandlern är beroende av IProductFactory och IProductRepository interfaces, vilket låter dom enkelt buta ut implementationen också. Vilket förljer
        Open and Closed principal, tillåter att "extend" funktinaliteten av systemet utan att ändra befintliga coden.

        ISP varje interface handler hade kunnat brytas ut till fler mindre 
         */
        private readonly IProductHandler _productHandler;
        private readonly IHelperHandler _helperHandler;
        private readonly ICategoryHandler _categoryHandler;
        private readonly IDiscountHandler _dicountHandler;
        public AdminController(IProductHandler productHandler, IHelperHandler helperHandler, ICategoryHandler categoryHandler, IDiscountHandler dicountHandler)
        {
            _productHandler = productHandler;
            _helperHandler = helperHandler;
            _categoryHandler = categoryHandler;
            _dicountHandler = dicountHandler;
        }

        public async Task<IActionResult> Index()
        {
            //add default discount
            await _helperHandler.AddDefaultDiscount("No Discount");

            var list = await _productHandler.GetAllProductsAsync();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            //pass the categoryMenu and discountMenu list to view
            var categoryMenu = await _helperHandler.CategoryMenuAsync();
            if (categoryMenu.Any())
            {
                ViewBag.CategorysMenu = categoryMenu; 
            }
            ViewBag.DiscountsMenu = await _helperHandler.DiscountMenuAsync();

            var productModel = _productHandler.CreateProductAsync();
            return View(productModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductModel model)
        {
            if (ModelState.IsValid)
            {
                await _productHandler.CreateProductAsync(model);
                return RedirectToAction("Index");
            }

            return RedirectToAction("CreateProduct");

        }
        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            var model = _categoryHandler.CreateCategory();
            return View(model);
        }
        [HttpPost]
        [Route("CreateCategory")]
        public async Task <IActionResult> CreateCategory(CreateCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryHandler.CreateCategoryAsync(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult CreateDiscount()
        {
            var discountView = _dicountHandler.CreateDiscount();
            return View(discountView);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountModel model)
        {
            if (ModelState.IsValid)
            {
                await _dicountHandler.CreateDiscountAsync(model);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
 
   
}
