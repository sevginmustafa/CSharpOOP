using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddOperationShouldAddElementAtTheNextFreeCell()
        {
            //Arrange
            Database database = new Database(new int[] { 1, 2 });

            //Act
            database.Add(7);
            int expectedResult = database.Fetch()[2];
            int expectedCountResult = 3;

            //Assert
            Assert.AreEqual(expectedResult, 7);
            Assert.AreEqual(expectedCountResult, database.Count);
        }

        [Test]
        public void AddOperationShouldThrowExceptionIfAddMoreThan16Elements()
        {
            //Arrange
            int[] array = Enumerable.Range(1, 16).ToArray();
            Database database = new Database(array);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void RemoveOperationShouldRemoveTheElementAtTheLastindex()
        {
            //Arrange
            Database database = new Database(new int[] { 1, 2 });

            //Act
            int expectedResult = database.Fetch()[0];
            database.Remove();
            int actualResult = database.Fetch()[0];
            int expectedCountResult = 1;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCountResult, database.Count);
        }

        [Test]
        public void RemoveOperationShouldThrowExceptionIfArrayIsEmpty()
        {
            //Arrange
            Database database = new Database();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnTheElementsAsArray()
        {
            //Arrange
            int[] array = { 1, 2, 3 };
            Database database = new Database(array);

            //Act
            int[] expectedResult = database.Fetch();

            //Assert
            CollectionAssert.AreEqual(expectedResult, array);
        }
    }
}