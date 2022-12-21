namespace Code.Pattern.Products.Models
{
    public interface IDiscountModel
    {
        public string DiscountName { get; set; } 
        public decimal DiscountAmount { get; set; } 
    }
    public class DiscountModel :  IDiscountModel
    {
        public string DiscountName { get ; set ; }
        public decimal DiscountAmount { get ; set; }
    }
}
