using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Code.Pattern.Products.Models.Entites
{
    public class ProductCategoryEntity
    {
        
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CategoryName { get; set; } = null!;

        //Realtion to products

        public ICollection<ProductEntity> Products { get; set; } = null!;

    }
}
