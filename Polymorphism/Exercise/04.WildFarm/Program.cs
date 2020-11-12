using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Foods;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            Food food = null;

            string input = string.Empty;

            int lineCounter = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();

                if (lineCounter % 2 == 0)
                {
                    string animalType = info[0];
                    string name = info[1];
                    double weight = double.Parse(info[2]);

                    if (animalType == "Cat")
                    {
                        string livingRegion = info[3];
                        string breed = info[4];

                        animals.Add(new Cat(name, weight, livingRegion, breed));
                    }
                    else if (animalType == "Tiger")
                    {
                        string livingRegion = info[3];
                        string breed = info[4];

                        animals.Add(new Tiger(name, weight, livingRegion, breed));
                    }
                    else if (animalType == "Owl")
                    {
                        double wingSize = double.Parse(info[3]);

                        animals.Add(new Owl(name, weight, wingSize));
                    }
                    else if (animalType == "Hen")
                    {
                        double wingSize = double.Parse(info[3]);

                        animals.Add(new Hen(name, weight, wingSize));
                    }
                    else if (animalType == "Mouse")
                    {
                        string livingRegion = info[3];

                        animals.Add(new Mouse(name, weight, livingRegion));
                    }
                    else if (animalType == "Dog")
                    {
                        string livingRegion = info[3];

                        animals.Add(new Dog(name, weight, livingRegion));
                    }
                }
                else
                {
                    string foodType = info[0];
                    int quantity = int.Parse(info[1]);

                    if (foodType == "Fruit")
                    {
                        food = new Fruit(quantity);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(quantity);
                    }
                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(quantity);
                    }
                    else if (foodType == "Vegetable")
                    {
                        food = new Vegetable(quantity);
                    }

                    Console.WriteLine(animals[animals.Count - 1].AskForFood());
                    animals[animals.Count - 1].CheckFoodType(food);
                }
               
                lineCounter++;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
