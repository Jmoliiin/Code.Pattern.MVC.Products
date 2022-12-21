using Code.Pattern.Products.Models.BaseModels;

namespace Code.Pattern.Products.Models.ViewModels
{
    public class ProductListViewModel
    {
       public List<BaseProductModel>? ProductList { get; set; }
        public List<CategoryModel>? CategoryList { get; set; } 
    }
}
