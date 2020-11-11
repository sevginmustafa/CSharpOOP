using _04.WildFarm.Models.Foods;
using System;

namespace _04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double WEIGHT_GAIN = 0.25;

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Hoot Hoot";
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
