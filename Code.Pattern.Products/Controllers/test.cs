using Microsoft.AspNetCore.Mvc;

namespace Code.Pattern.Products.Controllers
{
    public class test : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
