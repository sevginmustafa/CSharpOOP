using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputPizza = Console.ReadLine().Split();
                string namePizza = inputPizza[1];

                string[] inputDough = Console.ReadLine().Split();
                string flour = inputDough[1];
                string bakingTechnique = inputDough[2];
                int weightDough = int.Parse(inputDough[3]);

                Pizza pizza = new Pizza(namePizza, new Dough(flour, bakingTechnique, weightDough));

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] inputTopping = input.Split();
                    string type = inputTopping[1];
                    int weight = int.Parse(inputTopping[2]);
                    pizza.AddTopping(new Topping(type, weight));
                }

                double totalCalories = pizza.Dough.GetCalories();

                foreach (var topping in pizza.Toppings)
                {
                    totalCalories += topping.GetCalories();
                }

                Console.WriteLine($"{pizza.Name} - {totalCalories:f2} Calories.");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
