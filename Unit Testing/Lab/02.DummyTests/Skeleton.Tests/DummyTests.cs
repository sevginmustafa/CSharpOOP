using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyShouldLoseHealthIfAttacked()
    {
        //Arrange
        Dummy dummy = new Dummy(100, 100);

        //Act
        dummy.TakeAttack(10);

        //Assert
        int expectedResult = 90;
        int actualResult = dummy.Health;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DeadDummyShouldThrowInvalidOperationException()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 100);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(100));
    }

    [Test]
    public void DeadDummyShouldGiveXP()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 100);

        //Act - Assert
        int expectedResult = 100;
        int actualResult = dummy.GiveExperience();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void AliveDummyShouldNotGiveXP()
    {
        //Arrange
        Dummy dummy = new Dummy(100, 100);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
