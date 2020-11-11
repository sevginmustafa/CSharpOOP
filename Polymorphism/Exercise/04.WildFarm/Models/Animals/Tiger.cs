using _04.WildFarm.Models.Foods;
using System;

namespace _04.WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double WEIGHT_GAIN = 1;

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
        }

        public override void CheckFoodType(Food food)
        {
            if (food.GetType().Name == "Meat" )
            {
                Weight += WEIGHT_GAIN * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
