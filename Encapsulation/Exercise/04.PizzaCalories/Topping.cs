using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int CaloriesPerGram = 2;
        string type;
        int weight;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0 && value <= 50)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
            }
        }

        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }

        public double GetCalories()
        {
            double modifier = 1;

            if (Type.ToLower() == "meat")
            {
                modifier = 1.2;
            }
            else if (Type.ToLower() == "veggies")
            {
                modifier = 0.8;
            }
            else if (Type.ToLower() == "cheese")
            {
                modifier = 1.1;
            }
            else
            {
                modifier = 0.9;
            }

            return CaloriesPerGram * Weight * modifier;
        }
    }
}
