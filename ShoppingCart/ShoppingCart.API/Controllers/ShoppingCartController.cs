using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        // GET api/<ValuesController>/5
        [HttpGet("discount/{code}")]
        public double Discount(string code)
        {
            switch (code)
            {
                case string s when s.Equals("rkid", StringComparison.OrdinalIgnoreCase): 
                    return 0.05;
                case string s when s.Equals("madferit", StringComparison.OrdinalIgnoreCase):
                    return 0.5;
                    default: return 1;
            }          
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
