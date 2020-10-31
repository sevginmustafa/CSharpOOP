using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] info = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info[2];


                if (age > 0 && (gender == "Male" || gender == "Female"))
                {
                    Animal animal = null;

                    if (input == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (input == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (input == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (input == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (input == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }

                    animals.Add(animal);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
