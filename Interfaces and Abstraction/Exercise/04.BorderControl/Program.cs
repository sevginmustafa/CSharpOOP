using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> result = new List<IIdentifiable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();

                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];

                    result.Add(new Citizen(name, age, id));
                }
                else
                {
                    string model = info[0];
                    string id = info[1];

                    result.Add(new Robot(model, id));
                }
            }

            string checkCode = Console.ReadLine();

            foreach (var item in result.Where(x=>x.Id.EndsWith(checkCode)))
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
