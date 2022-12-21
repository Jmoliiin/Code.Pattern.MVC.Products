using Code.Pattern.Products.Models;
using Code.Pattern.Products.Models.Admin;
using Code.Pattern.Products.Models.Admin.CreateModels;
using Code.Pattern.Products.Models.Entites;

namespace Code.Pattern.Products.Factorys
{
    public interface IDiscountFactory
    {
        CreateDiscountModel CreateDiscount();
        DiscountEntity DiscountEntity();
        DiscountEntity DiscountEntity(CreateDiscountModel model);
        
        List<DiscountMenuModel> DiscountList();
        DiscountMenuModel DiscountMenu(DiscountEntity discountEntity);
        
    }
    public class DiscountFactory : IDiscountFactory
    {
        public CreateDiscountModel CreateDiscount()
        {
            return new CreateDiscountModel();
        }

        public DiscountEntity DiscountEntity(CreateDiscountModel model)
        {
            return new DiscountEntity() { Name=model.DiscountName,Amount=model.DiscountAmount};
        }
        public DiscountEntity DiscountEntity()
        {
            return new DiscountEntity();
        }
        public List<DiscountMenuModel> DiscountList()
        {
            return new List <DiscountMenuModel>();
        }

        public DiscountMenuModel DiscountMenu( DiscountEntity discountEntity)
        {
            return new DiscountMenuModel() { DiscountName= discountEntity.Name };
        }
    }
}
