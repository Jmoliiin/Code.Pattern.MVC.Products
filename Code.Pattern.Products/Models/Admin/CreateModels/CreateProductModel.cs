namespace Code.Pattern.Products.Models.Admin.CreateModels
{
    public class CreateProductModel
    {
        public string ArticleNumber { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public string Category { get; set; } = null!;
        public int Quantity { get; set; } = 0!;
        public string DiscountName { get; set; } = string.Empty!;
    }
}
