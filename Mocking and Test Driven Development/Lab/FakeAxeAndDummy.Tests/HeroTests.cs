using FakeAxeAndDummy;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroShouldGainXPWhenTargetDies()
    {
        //Arrange
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        fakeTarget.Setup(x => x.GiveExperience()).Returns(20);
        fakeTarget.Setup(x => x.IsDead()).Returns(true);

        Hero hero = new Hero("Pesho", fakeWeapon.Object);

        //Act
        hero.Attack(fakeTarget.Object);
        int expectedResult = 20;
        int actualResult = hero.Experience;

        //Assert
        Assert.AreEqual(expectedResult,actualResult);
    }
}