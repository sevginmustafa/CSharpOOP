using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> all = new List<IBirthable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();

                if (info[0] == "Citizen")
                {
                    string name = info[1];
                    int age = int.Parse(info[2]);
                    string id = info[3];
                    string birthdate = info[4];

                    all.Add(new Citizen(name, age, id, birthdate));
                }
                else if (info[0] == "Pet")
                {
                    string name = info[1];
                    string birthdate = info[2];

                    all.Add(new Pet(name, birthdate));
                }
            }

            string yearOfBirth = Console.ReadLine();

            foreach (var item in all.Where(x => x.Birthdate.EndsWith(yearOfBirth)))
            {
                Console.WriteLine(item.Birthdate);
            }
        }
    }
}
