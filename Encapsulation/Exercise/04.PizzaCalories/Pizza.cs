using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }
        public Dough Dough { get; set; }
        public List<Topping> Toppings { get; set; }

        public Pizza(string name,Dough dough)
        {
            Toppings = new List<Topping>();
            Name = name;
            Dough = dough;
        }

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count <= 10)
            {
                Toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
    }
}
