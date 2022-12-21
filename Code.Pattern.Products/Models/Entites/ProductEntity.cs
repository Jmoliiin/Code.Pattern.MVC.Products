using Code.Pattern.Products.Models.BaseModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code.Pattern.Products.Models.Entites
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ArticleNumber { get; set; } = null!;
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; } = null!;
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string ProductDescription { get; set; } = null!;
        [Required]
        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }
        [Column(TypeName = "datetime2")]
        public  DateTime? ProductCreated { get; set; } = DateTime.Now;
        [Column(TypeName = "datetime2")]
        public DateTime? ProductModified { get; set; } = DateTime.Now;

        //FK
        public int ProductCategoryId { get; set; }
        public ProductCategoryEntity ProductCategory { get; set; } 

        //FK
        public int ProductInventoryId { get; set; }
        public ProductInventoryEntity ProductInventory { get; set;}

        public int DiscountId { get; set; }
        public DiscountEntity Discount { get; set; }
    }
}
