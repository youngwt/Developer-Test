using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Data;
using ShoppingCart.Data.Interface;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordRepository _recordRepository;

        public RecordsController(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        [HttpGet]
        //[EnableCors("CorsPolicy")]
        public IEnumerable<Record> Get()
        {
            return _recordRepository.GetAllRecords();
        }
    }
}
