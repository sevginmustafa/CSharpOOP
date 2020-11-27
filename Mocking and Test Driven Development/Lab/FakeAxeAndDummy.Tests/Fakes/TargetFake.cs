namespace FakeAxeAndDummy.Tests.Fakes
{
    public class TargetFake : ITarget
    {
        public int Health => 20;

        public int GiveExperience()
        {
            return Health;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
        }
    }
}
