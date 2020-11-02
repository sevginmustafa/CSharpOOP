using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const int CaloriesPerGram = 2;
        string flourType;
        string bakingTechnique;
        int weight;

        public string FlourType
        {
            get
            {
                return flourType;
            }
            set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            set
            {
                if (value.ToLower() == "chewy" || value.ToLower() == "crispy" || value.ToLower() == "homemade")
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
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
                if (value > 0 && value <= 200)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public double GetCalories()
        {
            double modifier = 1;

            if (FlourType.ToLower() == "white")
            {
                modifier = 1.5;
            }

            if (BakingTechnique.ToLower() == "chewy")
            {
                modifier *= 1.1;
            }
            else if (BakingTechnique.ToLower() == "crispy")
            {
                modifier *= 0.9;
            }

            return CaloriesPerGram * Weight * modifier;
        }
    }
}
