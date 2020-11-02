using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] allPeople = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
                string[] allProducts = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < allPeople.Length; i += 2)
                {
                    string name = allPeople[i];
                    int money = int.Parse(allPeople[i + 1]);

                    people.Add(new Person(name, money));
                }

                for (int i = 0; i < allProducts.Length; i += 2)
                {
                    string name = allProducts[i];
                    int cost = int.Parse(allProducts[i + 1]);

                    products.Add(new Product(name, cost));
                }

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = command[0];
                    string productName = command[1];

                    int currentPersonIndex = people.FindIndex(x => x.Name == name);
                    int currentProductIndex = products.FindIndex(x => x.Name == productName);

                    if (currentPersonIndex != -1)
                    {
                        people[currentPersonIndex].AddProduct(products[currentProductIndex]);
                    }
                }

                foreach (var person in people)
                {
                    if (person.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
                    }
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
