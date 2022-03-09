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

        /// <summary>
        /// Gets the complete list of records
        /// </summary>
        /// <returns>A list of all available albums</returns>
        [HttpGet]     
        public IEnumerable<Record> Get()
        {
            return _recordRepository.GetAllRecords();
        }
    }
}
