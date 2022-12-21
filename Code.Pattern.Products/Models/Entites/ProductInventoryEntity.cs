using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Code.Pattern.Products.Models.Entites
{
    public class ProductInventoryEntity
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }

        public ICollection<ProductEntity> Products { get; set; } = null!;
    }
}
