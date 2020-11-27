using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("name", 100, 100)]
        public void ConstructorShouldBeInitializedCorrectly(
            string name,
            int damage,
            int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);

            //Act - Assert
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void PropertyNameShouldThrowExceptionIfIsNullOrWhiteSpace(string name)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Warrior(name, 100, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-60)]
        public void PropertyDamageeShouldThrowExceptionIfIsBelowOrEqualZero(int damage)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Warrior("name", damage, 100));
        }

        [Test]
        [TestCase(-60)]
        public void PropertyHPShouldThrowExceptionIfIsBelowZero(int hp)
        {
            //Arrange - Act - Assert
            Assert.Throws<ArgumentException>(() => new Warrior("name", 100, hp));
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void MethodAttackShouldThrowExceptionIfHPIsBelowOrEqualMinAttackHP(int attackerHP)
        {
            //Arrange
            Warrior attacker = new Warrior("name", 10, attackerHP);
            Warrior defender = new Warrior("name", 10, 40);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void MethodAttackShouldThrowExceptionIfEnemyHPIsBelowOrEqualMinAttackHP(int defenderHP)
        {
            //Arrange
            Warrior attacker = new Warrior("name", 10, 50);
            Warrior defender = new Warrior("name", 10, defenderHP);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(99)]
        public void MethodAttackShouldThrowExceptionIfHPIsBelowEnemyDamage(int hp)
        {
            //Arrange
            Warrior warrior = new Warrior("name", 100, hp);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("enemy", 100, 100)));
        }

        [Test]
        [TestCase(100, 0)]
        [TestCase(150, 50)]
        public void MethodAttackShouldSuccessIfHPIsBiggerOrEqualEnemyDamage(int hp, int expectedResult)
        {
            //Arrange
            Warrior warrior = new Warrior("name", 100, hp);
            Warrior enemyWarrior = new Warrior("name", 100, 100);

            //Act
            warrior.Attack(enemyWarrior);
            int actualResult = warrior.HP;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(120, 0)]
        public void MethodAttackShouldFixEnemyHpToZeroIfDamageIsBigger(int damage, int expectedResult)
        {
            //Arrange
            Warrior warrior = new Warrior("name", damage, 100);
            Warrior enemyWarrior = new Warrior("name", 100, 100);

            //Act
            warrior.Attack(enemyWarrior);
            int actualResult = warrior.HP;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(80, 20)]
        [TestCase(100, 0)]
        public void MethodAttackShouldDecreaseEnemyHPIfDamageIsBelowOrEqualEnemyHP(int damage, int expectedResult)
        {
            //Arrange
            Warrior warrior = new Warrior("name", damage, 100);
            Warrior enemyWarrior = new Warrior("name", 100, 100);

            //Act
            warrior.Attack(enemyWarrior);
            int actualResult = enemyWarrior.HP;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}