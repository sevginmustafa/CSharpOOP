namespace FakeAxeAndDummy.Tests.Fakes
{
    class WeaponFake : IWeapon
    {
        public int AttackPoints => 100;

        public int DurabilityPoints => 100;

        public void Attack(ITarget target)
        {
        }
    }
}
