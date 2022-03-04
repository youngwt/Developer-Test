using ShoppingCart.Data.Interface;

namespace ShoppingCart.Data.Implementation
{
    public class RecordRepository : IRecordRepository
    {
        // for now we are just going to have a dictionary of a few items - of course in real life this would be stored in a db
        private readonly IDictionary<int, Record> _records;

        public RecordRepository()
        {
            _records = new Dictionary<int, Record>();

            // Just to get the ball rolling add a few albums
            _records.Add(0, new Record()
            {
                Id = 0,
                Artist = "The Beatles",
                Price = 13.99d,
                Title = "Abbey Road",
                Year = 1969
            });

            _records.Add(1, new Record()
            {
                Id = 1,
                Artist = "Oasis",
                Price = 0.99d,
                Title = "(What's The Story) Morning Glory",
                Year = 1995
            });

            _records.Add(2, new Record()
            {
                Id = 2,
                Artist = "Embrace",
                Price = 9.99d,
                Title = "The Good Will Out",
                Year = 1998
            });
        }

        public Record Get(int id)
        {
            return _records[id];
        }

        public IEnumerable<Record> GetAllRecords()
        {
            return _records.Values.ToList();
        }
    }
}
