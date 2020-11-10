namespace _03.Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name)
        {
            Name = name;
        }

        protected string Name { get; }
        public abstract int Power { get; }

        public abstract string CastAbility();
    }
}
