using Code.Pattern.Products.Models.BaseModels;

namespace Code.Pattern.Products.Models.ViewModels
{
    public class CategoryAndAllProductListViewModel
    {
        public List<BaseProductModel>? ProductList { get; set; }
        public CategoryModel? CategoryModel { get; set; }
    }
}
