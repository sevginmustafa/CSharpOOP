using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("BMW", "X6", 10, 100)]
        public void ConstructorShouldBeInitializedCorrectly(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            //Arrange
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act - Assert
            Assert.AreEqual("BMW", car.Make);
            Assert.AreEqual("X6", car.Model);
            Assert.AreEqual(10, car.FuelConsumption);
            Assert.AreEqual(100, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void PropertyMakeShouldThrowExcepsionIfValueIsNullOrEmpty(
            string make)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Car(make, "X6", 10, 100));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void PropertyModelShouldThrowExcepsionIfValueIsNullOrEmpty(
            string model)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Car("BMW", model, 10, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-40)]
        public void PropertyFuelConsumptionShouldThrowExcepsionIfValueIsBelowOrEqualToZero(
            double fuelConsumption)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X6", fuelConsumption, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-40)]
        public void PropertyFuelCapacityShouldThrowExcepsionIfValueIsBelowOrEqualToZero(
           double fuelCapacity)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X6", 10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-40)]
        public void RefuelMethodShouldThrowExcepsionIfValueOfFuelToRefuelIsBelowOrEqualToZero(
         double fuelToRefuel)
        {
            //Arrange 
            Car car = new Car("BMW", "X6", 10, 100);

            //Act - Assert
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
        }

        [Test]
        [TestCase(50, 100, 50)]
        [TestCase(150, 100, 100)]
        public void RefuelMethodShouldTakeFuelAmountNotMoreThanTheCapacity(
            double fuelToRefuel,
            double fuelCapacity,
            double expectedResult)
        {
            //Arrange
            Car car = new Car("BMW", "X6", 10, fuelCapacity);

            //Act
            car.Refuel(fuelToRefuel);
            double actualResult = car.FuelAmount;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(10, 101)]
        [TestCase(9, 100)]
        public void DriveMethodShouldThrowExcepsionIfFuelAmountIsNotEnough(
         double fuelToRefuel,
         double distance)
        {
            //Arrange 
            Car car = new Car("BMW", "X6", 10, 100);

            //Act
            car.Refuel(fuelToRefuel);

            //Assert
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        [TestCase(20, 100, 10)]
        [TestCase(50, 300, 20)]
        public void DriveMethodShouldReduceTheFuelAmountAfterPassingTheDistance(
            double fuelToRefuel,
            double distance,
            double fuelAmountLeft)
        {
            //Arrange
            Car car = new Car("BMW", "X6", 10, 100);

            //Act
            car.Refuel(fuelToRefuel);
            car.Drive(distance);

            //Assert
            Assert.AreEqual(fuelAmountLeft, car.FuelAmount);
        }
    }
}