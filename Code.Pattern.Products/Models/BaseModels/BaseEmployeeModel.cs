namespace Code.Pattern.Products.Models.BaseModels
{
    public interface IBaseEmployee
    {

    }
    public abstract class BaseEmployeeModel: IBaseEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? StreetAdress { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
    }
}
