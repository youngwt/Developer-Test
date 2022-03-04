
namespace ShoppingCart.Data.Interface
{
    public interface IRecordRepository
    {
        public IEnumerable<Record> GetAllRecords();
        public Record Get(int id);
    }
}
