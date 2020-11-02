using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        string name;
        int money;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public int Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }
        public List<string> BagOfProducts { get; set; }

        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
        }

        public void AddProduct(Product product)
        {
            if (product.Cost <= Money)
            {
                Money -= product.Cost;
                BagOfProducts.Add(product.Name);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
    }
}
