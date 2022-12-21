namespace Code.Pattern.Products.Models.Entites
{
    public class DiscountEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Amount { get; set; } = 0!;
        public virtual ICollection<ProductEntity>? Products { get; set; }
    }
}
