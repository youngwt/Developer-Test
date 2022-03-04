using NUnit.Framework;
using ShoppingCart.API.Controllers;
using ShoppingCart.Data.Implementation;
using System.Linq;

namespace ShoppingCart.API.Tests
{
    internal class ShoppingCartTests
    {
        private ShoppingCartController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new ShoppingCartController();
        }

        [TestCase("rkid", 0.05)]
        [TestCase("RKID", 0.05)]
        [TestCase("madferit", 0.5)]
        [TestCase("qwerty", 1)]
        [TestCase("", 1)]
        [TestCase(null, 1)]
        public void CanGetDiscount(string code, double expectedDiscount)
        {
            // Arrange
            // managed in setup

            // Act
            var result = _controller.Discount(code);

            // Assert
            Assert.That(result, Is.EqualTo(expectedDiscount));
        }
    }
}
