using System;

namespace _09.ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input=Console.ReadLine())!="End")
            {
                string[] info = input.Split();

                string name = info[0];
                string country = info[1];
                int age = int.Parse(info[2]);

                Citizen citizen = new Citizen(name,country,age);
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
