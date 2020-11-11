using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; set; }

        public abstract string AskForFood();

        public abstract void CheckFoodType(Food food);
    }
}
