using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data.Interface;

namespace ShoppingCart.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IDiscountRepository _discountRepository;

        public ShoppingCartController(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        /// <summary>
        /// Returns the discount multiplier expressed in the range 0-1
        /// </summary>
        /// <remarks> Returning the default 1 effectively states that there is no discount for the code</remarks>
        /// <param name="code">The discount code</param>
        /// <returns>Discount multiplier between 0 and 1 </returns>
        [HttpGet("discount/{code}")]
        public double Discount(string code)
        {
            return _discountRepository.GetDiscount(code);
        }
    }
}
