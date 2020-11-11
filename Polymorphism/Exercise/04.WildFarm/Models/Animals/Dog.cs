using _04.WildFarm.Models.Foods;
using System;

namespace _04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double WEIGHT_GAIN = 0.4;

        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return "Woof!";
        }

        public override void CheckFoodType(Food food)
        {
            if (food.GetType().Name == "Meat")
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
