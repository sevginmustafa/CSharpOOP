namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    public class ProductStockTests
    {
        [Test]
        public void MethodAddShoulAddProducyToTheStock()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();

            //Act
            productStock.Add(product);
            int expectedResult = 1;
            int actualResult = productStock.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodAddShouldThrowExceptionIfProductExists()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();

            //Act 
            productStock.Add(product);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => productStock.Add(product));
        }

        [Test]
        [TestCase("Label", true)]
        [TestCase("Label2", false)]
        public void MethodContainsShouldWorkProperly(string label, bool expectedResult)
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            Product productToCheck = new Product(label, 4.6m, 2);
            ProductStock productStock = new ProductStock();

            //Act 
            productStock.Add(product);
            bool actualResult = productStock.Contains(productToCheck);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodFindShouldReturnTheNthProduct()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();

            //Act 
            productStock.Add(product);
            Product actualResult = productStock.Find(1);

            //Assert
            Assert.AreEqual(product, actualResult);
        }

        [Test]
        [TestCase(-6)]
        [TestCase(2)]
        [TestCase(0)]
        public void MethodFindShouldThrowExceptionIfIndexIsInvalid(int index)
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();

            //Act 
            productStock.Add(product);

            //Assert
            Assert.Throws<IndexOutOfRangeException>(()
                => productStock.Find(index));
        }

        [Test]
        public void MethodFindByLabelShouldReturnTheCorrectProduct()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();

            //Act 
            productStock.Add(product);
            Product actualResult = productStock.FindByLabel("Label");

            //Assert
            Assert.AreEqual(product, actualResult);
        }

        [Test]
        public void MethodFindByLebelShouldThrowExceptionIfLabelIsNotFound()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();

            //Act 
            productStock.Add(product);

            //Assert
            Assert.Throws<ArgumentException>(()
                => productStock.FindByLabel("Label2"));
        }

        [Test]
        public void MethodFindAllInPriceRangeShouldReturnTheCorrectProducts()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            Product product2 = new Product("Label2", 1.1m, 2);
            Product product3 = new Product("Label3", 6m, 2);
            ProductStock productStock = new ProductStock();
            Product[] expectedResult = new Product[2];
            expectedResult[0] = product3;
            expectedResult[1] = product;

            //Act 
            productStock.Add(product);
            productStock.Add(product2);
            productStock.Add(product3);

            Product[] actualResult = productStock.FindAllInPriceRange(4m, 6m);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodFindAllInPriceRangeShouldReturnEmptyCollectionIfPriceRangeIsNotCorrect()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();
            Product[] expectedResult = new Product[0];

            //Act 
            productStock.Add(product);

            Product[] actualResult = productStock.FindAllInPriceRange(12m, 16m);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodFindAllByPriceShouldReturnTheCorrectProducts()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            Product product2 = new Product("Label2",4.6m, 2);
            Product product3 = new Product("Label3", 6m, 2);
            ProductStock productStock = new ProductStock();
            Product[] expectedResult = new Product[2];
            expectedResult[0] = product;
            expectedResult[1] = product2;

            //Act 
            productStock.Add(product);
            productStock.Add(product2);
            productStock.Add(product3);

            Product[] actualResult = productStock.FindAllByPrice(4.6m);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodFindAllByPriceShouldReturnEmptyCollectionIfPriceIsNotCorrect()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();
            Product[] expectedResult = new Product[0];

            //Act 
            productStock.Add(product);

            Product[] actualResult = productStock.FindAllByPrice(6m);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodFindMostExpensiveProductsShouldWorkCorrectly()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            Product product2 = new Product("Label2", 6m, 2);
            ProductStock productStock = new ProductStock();

            //Act 
            productStock.Add(product);
            productStock.Add(product2);

            Product actualResult = productStock.FindMostExpensiveProducts();

            //Assert
            Assert.AreEqual(product2, actualResult);
        }

        [Test]
        public void MethodFindAllByQuantityShouldReturnTheCorrectProducts()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            Product product2 = new Product("Label2", 4.6m, 2);
            Product product3 = new Product("Label3", 6m, 4);
            ProductStock productStock = new ProductStock();
            Product[] expectedResult = new Product[2];
            expectedResult[0] = product;
            expectedResult[1] = product2;

            //Act 
            productStock.Add(product);
            productStock.Add(product2);
            productStock.Add(product3);

            Product[] actualResult = productStock.FindAllByQuantity(2);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodFindAllByQuantityShouldReturnEmptyCollectionIfQuantityIsNotCorrect()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();
            Product[] expectedResult = new Product[0];

            //Act 
            productStock.Add(product);

            Product[] actualResult = productStock.FindAllByPrice(6);

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodGetEnumeratorShouldReturnAllProducts()
        {
            //Arrange
            Product product = new Product("Label", 4.6m, 2);
            ProductStock productStock = new ProductStock();
            Product[] expectedResult = new Product[1];
            expectedResult[0] = product;

            //Act 
            productStock.Add(product);

            Product[] actualResult = productStock.GetEnumerator();

            //Assert
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
