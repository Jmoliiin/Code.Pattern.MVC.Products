using Code.Pattern.Products.Models.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Code.Pattern.Products.Models.BaseModels;

namespace Code.Pattern.Products.Models
{
    public interface IProducModel : IBaseProduct
    {
        //likovski s principal classarv, basemodel använder abstract

        // /DRY ärv från baseproductmodel.

        public class ProductModel : BaseProductModel, IProducModel
        {
            
        }
    }
}