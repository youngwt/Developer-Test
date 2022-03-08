using ShoppingCart.Data.Interface;

namespace ShoppingCart.Data.Implementation
{
    public class DiscountRepository : IDiscountRepository
    {
        public double GetDiscount(string code)
        {
            // obviously in  real life this would be data driven in a SQL db and the where clause would ignore case
            switch (code)
            {
                case string s when s.Equals("rkid", StringComparison.OrdinalIgnoreCase):
                    return 0.05;
                case string s when s.Equals("madferit", StringComparison.OrdinalIgnoreCase):
                    return 0.5;
                default: return 1;
            }
        }
    }
}
