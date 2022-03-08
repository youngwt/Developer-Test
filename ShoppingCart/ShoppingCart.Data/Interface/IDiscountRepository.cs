namespace ShoppingCart.Data.Interface
{
    public interface IDiscountRepository
    {
        double GetDiscount(string code);
    }
}
