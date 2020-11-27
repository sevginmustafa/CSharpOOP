namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        [Test]
        [TestCase("Label", 4.6, 2)]
        public void ConstructorShouldWorkProperly(string label, decimal price, int quantity)
        {
            //Arrange
            Product product = new Product(label, price, quantity);

            //Act - Assert
            Assert.AreEqual(product.Label, "Label");
            Assert.AreEqual(product.Price, 4.6);
            Assert.AreEqual(product.Quantity, 2);
        }

        [Test]
        [TestCase(null, 4.6, 2)]
        [TestCase("", 4.6, 2)]
        [TestCase("  ", 4.6, 2)]
        public void PropertyLabelShouldThrowExceptionIfIsNullOrWhiteSpace(string label, decimal price, int quantity)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(()
              => new Product(label, price, quantity));
        }

        [Test]
        [TestCase("Label", -4.6, 2)]
        [TestCase("Label", 0, 2)]
        public void PropertyPriceShouldThrowExceptionIfZeroOrBelow(string label, decimal price, int quantity)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(()
              => new Product(label, price, quantity));
        }

        [Test]
        [TestCase("Label", 4.6, -2)]
        public void PropertyQuantityShouldThrowExceptionIfNegative(string label, decimal price, int quantity)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(()
              => new Product(label, price, quantity));
        }
    }
}