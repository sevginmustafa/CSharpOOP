using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WEIGHT_GAIN= 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string AskForFood()
        {
            return "Cluck";
        }

        public override void CheckFoodType(Food food)
        {
            Weight += WEIGHT_GAIN * food.Quantity;
            FoodEaten += food.Quantity;
        }
    }
}
