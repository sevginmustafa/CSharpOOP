using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> all = new List<IBuyer>();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] info = Console.ReadLine().Split();

                if (info.Length == 4)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];
                    string birthdate = info[3];

                    all.Add(new Citizen(name, age, id, birthdate));
                }
                else
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string group = info[2];

                    all.Add(new Rebel(name, age, group));
                }

            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                IBuyer current = all.FirstOrDefault(x => x.Name == command);

                if (current != null)
                {
                    current.BuyFood();
                }
            }

            Console.WriteLine(all.Sum(x => x.Food));
        }
    }
}
