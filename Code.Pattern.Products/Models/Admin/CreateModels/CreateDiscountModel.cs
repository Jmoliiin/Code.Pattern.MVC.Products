namespace Code.Pattern.Products.Models.Admin.CreateModels
{
    public class CreateDiscountModel 
    {
        public string DiscountName { get; set; } = null!;
        public decimal DiscountAmount { get; set; } = decimal.Zero!;
    }
}
