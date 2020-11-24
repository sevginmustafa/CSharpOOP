using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            //Arrange
            Person[] people = new Person[16];

            for (int i = 1; i <= 16; i++)
            {
                people[i - 1] = new Person(i, "a" + i);
            }

            ExtendedDatabase extendedDatabase = new ExtendedDatabase(people);

            //Act - Assert
            int expectedResult = 16;
            int actualResult = extendedDatabase.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        public void ConstructorShouldThrowExceptionIfMoreThan16ElementsAdded()
        {
            //Arrange
            Person[] people = new Person[17];

            for (int i = 1; i <= 17; i++)
            {
                people[i - 1] = new Person(i, "a" + i);
            }

            //Act - Assert
            Assert.Throws<ArgumentException>(()
                => new ExtendedDatabase(people));
        }

        [Test]
        public void MethodAddShouldWorkProperly()
        {
            //Arrange
            Person person = new Person(12345, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();

            //Act
            extendedDatabase.Add(person);
            var expectedResult = 1;
            var actualResult = extendedDatabase.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodAddShouldThrowExceptionIfMoreThan16ElementsAreAdded()
        {
            //Arrange
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();

            for (int i = 1; i <= 16; i++)
            {
                extendedDatabase.Add(new Person(i, "a" + i));
            }

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => extendedDatabase.Add(new Person(17, "a17")));
        }

        [Test]
        [TestCase(123, "Pesho")]
        [TestCase(12345, "Ivan")]
        public void MethodAddShouldThrowExceptionIfThereIsPersonWithTheSameUsernameOrID(long id, string name)
        {
            //Arrange
            Person person = new Person(123, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => extendedDatabase.Add(new Person(id, name)));
        }

        [Test]
        public void MethodRemoveShouldWorkProperly()
        {
            //Arrange
            Person person = new Person(12345, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);

            //Act
            extendedDatabase.Remove();
            var expectedResult = 0;
            var actualResult = extendedDatabase.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodRemoveShouldThrowExceptionIfEmpty()
        {
            //Arrange
            ExtendedDatabase extendedDatabase = new ExtendedDatabase();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => extendedDatabase.Remove());
        }

        [Test]
        public void MethodFindByUsernameShouldWorkProperly()
        {
            //Arrange
            Person person = new Person(12345, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);

            //Act
            string expectedResult = "Ivan";
            string actualResult = extendedDatabase.FindByUsername("Ivan").UserName;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodFindByUsernameShouldThrowExceptionIfTherIsNoSuchUsername()
        {
            //Arrange
            Person person = new Person(12345, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => extendedDatabase.FindByUsername("Gosho"));
        }

        [Test]
        [TestCase(123, "")]
        [TestCase(321, null)]
        public void MethodFindByUsernameShouldThrowExceptionIfUsernameIsNullOrEmpty(long id, string name)
        {
            //Arrange
            Person person = new Person(12345, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);

            //Act - Assert
            Assert.Throws<ArgumentNullException>(()
                => extendedDatabase.FindByUsername(name));
        }

        [Test]
        public void MethodFindByIDShouldWorkProperly()
        {
            //Arrange
            Person person = new Person(12345, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);

            //Act
            long expectedResult = 12345;
            long actualResult = extendedDatabase.FindById(12345).Id;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MethodFindByIDShouldThrowExceptionIfIDIsNotPositiveNumber()
        {
            //Arrange
            Person person = new Person(20, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);

            //Act - Assert
            Assert.Throws<ArgumentOutOfRangeException>(()
                => extendedDatabase.FindById(-20));
        }

        [Test]
        public void MethodFindByIDShouldThrowExceptionIfThereIsNoSuchId()
        {
            //Arrange
            Person person = new Person(12345, "Ivan");
            ExtendedDatabase extendedDatabase = new ExtendedDatabase(person);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => extendedDatabase.FindById(123));
        }
    }
}