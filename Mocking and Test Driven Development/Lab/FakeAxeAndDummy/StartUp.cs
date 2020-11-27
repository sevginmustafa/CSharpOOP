using FakeAxeAndDummy;

public class StartUp
{
    static void Main(string[] args)
    {
        ITarget target = new Dummy(100, 100);
        IWeapon weapon = new Axe(100, 100);

        Hero hero = new Hero("Pesho", weapon);
    }
}
