using NUnit.Framework;
using ShoppingCart.API.Controllers;
using ShoppingCart.Data.Implementation;
using System.Linq;

namespace ShoppingCart.Tests.API
{
    internal class RecordApiTests
    {
        private RecordsController _recordController;

        [SetUp]
        public void SetupFixture()
        {
            _recordController = new RecordsController(new RecordRepository());
        }

        [Test]
        public void CanGetAllRecords()
        {
            // Arrange
            // done in setup

            // Act
            var result = _recordController.Get();

            // Assert

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);

            Assert.That(result.FirstOrDefault(x => x.Artist == "The Beatles"), Is.Not.Null);
        }
    }
}