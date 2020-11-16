namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle car = new Vehicle(55,55);

            System.Console.WriteLine(car.DefaultFuelConsumption);
        }
    }
}
