namespace Code.Pattern.Products.Models.BaseModels
{
    //open and close pricipal
    public interface IBaseProduct 
    {
        int Id { get; set; }
        string ArticleNumber { get; set; }

        string ProductName { get; set; }

        string ProductDescription { get; set; }

        decimal ProductPrice { get; set; }

        string? Category { get; set; }
        int? Quantity { get; set; }
        decimal? DiscountAmount { get; set; }
        decimal PriceWithDiscount { get; set; }


    }
    //LSP - gör den abstract så ingen kan göra instans av classen utan bara ärva den. Då vet alla vad som ska finnas på varje produkt
    public abstract class BaseProductModel : IBaseProduct
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public string ProductDescription { get; set; } = null!;

        public decimal ProductPrice { get; set; }

        public string? Category { get; set; } 
        public int? Quantity { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal PriceWithDiscount { get; set; } = 0;
    }
}
