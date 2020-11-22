using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100, 100, 100, 100, 99)]
    public void WeaponShouldLoseDurabilityAfterAttack(
        int health, int experience,
        int attack, int durability,
        int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);
        Axe axe = new Axe(attack, durability);

        //Act
        axe.Attack(dummy);

        //Assert
        int actualResult = axe.DurabilityPoints;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void AttackShouldThrowInvalidOperationExceptionWhenDurabilityIsZero()
    {
        //Arrange
        Dummy dummy = new Dummy(100, 100);
        Axe axe = new Axe(100, 0);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}