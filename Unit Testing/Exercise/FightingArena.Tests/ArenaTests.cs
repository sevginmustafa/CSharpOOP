
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MethodEnrollShouldThrowExceptionIfWarriorIsAlreadyEnrolled()
        {
            //Arrange
            Arena arena = new Arena();

            //Act
            arena.Enroll(new Warrior("Ivan", 100, 100));

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(new Warrior("Ivan", 50, 50)));
        }

        [Test]
        public void MethodEnrollShouldAddWarriorToTheList()
        {
            //Arrange
            Arena arena = new Arena();

            //Act
            arena.Enroll(new Warrior("Ivan", 100, 100));
            int expectedCount = 1;
            int actualCount = arena.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase("Pesho", "Georgi")]
        [TestCase("Ivan", "Stefan")]
        [TestCase("Stefan", "Pesho")]
        public void MethodFightShouldThrowExceptionIfAttackerOrDefenderNameIsMissing(string attackerName, string defenderName)
        {
            //Arrange
            Arena arena = new Arena();

            //Act
            arena.Enroll(new Warrior("Ivan", 100, 100));
            arena.Enroll(new Warrior("Georgi", 50, 100));

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attackerName, defenderName));
        }

        [Test]
        public void MethodFightShouldWorkProperly()
        {
            //Arrange
            Arena arena = new Arena();

            //Act - Assert
            arena.Enroll(new Warrior("Ivan", 50, 100));
            arena.Enroll(new Warrior("Georgi", 50, 100));

            arena.Fight("Ivan", "Georgi");

            int ivanHP = arena.Warriors.FirstOrDefault(x => x.Name == "Ivan").HP;
            int georgiHP = arena.Warriors.FirstOrDefault(x => x.Name == "Georgi").HP;

            Assert.AreEqual(georgiHP, 50);
            Assert.AreEqual(ivanHP, 50);
        }
    }
}
